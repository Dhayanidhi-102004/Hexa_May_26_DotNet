using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using LibraryMembershipApp.Models;
using LibraryMembershipApp.Interfaces;
using LibraryMembershipApp.Services;

namespace LibraryMembershipApp.Tests
{
    [TestFixture]
    public class LibraryServiceTests
    {
        private Mock<IBookRepository> _bookRepositoryMock;
        private Mock<IMemberRepository> _memberRepositoryMock;
        private Mock<INotificationService> _notificationServiceMock;
        private LibraryService _libraryService;
        [SetUp]
        public void Setup()
        {
            _bookRepositoryMock = new Mock<IBookRepository>();
            _memberRepositoryMock = new Mock<IMemberRepository>();
            _notificationServiceMock = new Mock<INotificationService>();
            _libraryService = new LibraryService(_bookRepositoryMock.Object, _memberRepositoryMock.Object, _notificationServiceMock.Object);
        }
        [Test]
        public void BorrowBook_WhenAllConditionsAreValid_ShouldReturnSuccessMessage()
        {

            var member = new Member
            {
                MemberId = 1,
                MemberName = "John Doe",
                Email = "John@gmail.com",
                IsActive = true,
                BorrowedBookCount = 0
            };
            _memberRepositoryMock.Setup(repo => repo.GetMemberById(1))
                .Returns(member);
            var book = new Book
            {
                BookId = 1,
                BookTitle = "Wings Of Fire",
                AuthorName = "Abdul kalam",
                IsAvailable = true
            };
            _bookRepositoryMock.Setup(repo => repo.GetBookById(1))
                .Returns(book);
            var libraryService = new LibraryService(_bookRepositoryMock.Object, _memberRepositoryMock.Object, _notificationServiceMock.Object);

            var result = libraryService.BorrowBook(1, 1);
            Assert.That(result, Is.EqualTo("Book borrowed successfully"));
            _bookRepositoryMock.Verify(repo => repo.MarkBookAsBorrowed(1), Times.Once);
            _memberRepositoryMock.Verify(repo => repo.UpdateBorrowedBookCount(1), Times.Once);
            _notificationServiceMock.Verify(service => service.SendBorrowNotification("John@gmail.com", "Wings Of Fire"), Times.Once);
        }
        [Test]
        public void BorrowBook_WhenMemberDoesNotExist_ShouldReturnMemberNotFound()
        {
            _memberRepositoryMock.Setup(repo => repo.GetMemberById(100))
                .Returns((Member?)null);
            var libraryService = new LibraryService(_bookRepositoryMock.Object, _memberRepositoryMock.Object, _notificationServiceMock.Object);
            var result = libraryService.BorrowBook(100, 1);
            Assert.That(result, Is.EqualTo("Member not found"));
            _bookRepositoryMock.Verify(repo => repo.GetBookById(It.IsAny<int>()), Times.Never);
            _memberRepositoryMock.Verify(repo => repo.UpdateBorrowedBookCount(It.IsAny<int>()), Times.Never);
            _notificationServiceMock.Verify(service => service.SendBorrowNotification(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
        }
        [Test]
        public void BorrowBook_WhenMemberIsInactive_ShouldReturnMemberIsNotActive()
        {
            var member = new Member
            {
                MemberId = 2,
                MemberName = "Jane Doe",
                Email = "Jane@gmail.com",
                IsActive = false,
                BorrowedBookCount = 0
            };
            _memberRepositoryMock.Setup(repo => repo.GetMemberById(2))
                .Returns(member);
            var libraryService = new LibraryService(_bookRepositoryMock.Object, _memberRepositoryMock.Object, _notificationServiceMock.Object);
            var result = libraryService.BorrowBook(2, 1);
            Assert.That(result, Is.EqualTo("Member is not active"));
            _bookRepositoryMock.Verify(repo => repo.GetBookById(It.IsAny<int>()), Times.Never);
            _memberRepositoryMock.Verify(repo => repo.UpdateBorrowedBookCount(It.IsAny<int>()), Times.Never);
            _notificationServiceMock.Verify(service => service.SendBorrowNotification(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
        }
        [Test]
        public void BorrowBook_WhenBookDoesNotExist_ShouldReturnBookNotFound()
        {
            int memberId = 1;
            int bookId = 100;
            var activeMember = new Member
            {
                MemberId = memberId,
                MemberName = "John Doe",
                Email = "john@gmail.com",
                IsActive = true,
                BorrowedBookCount = 0
            };
            _memberRepositoryMock.Setup(repo => repo.GetMemberById(memberId)).Returns(activeMember);
            _bookRepositoryMock.Setup(repo => repo.GetBookById(bookId))
                .Returns((Book?)null);
            var libraryService = new LibraryService(_bookRepositoryMock.Object, _memberRepositoryMock.Object, _notificationServiceMock.Object);
            var result = libraryService.BorrowBook(1, 100);
            Assert.That(result, Is.EqualTo("Book not found"));
            _bookRepositoryMock.Verify(repo => repo.MarkBookAsBorrowed(It.IsAny<int>()), Times.Never);
            _memberRepositoryMock.Verify(repo => repo.UpdateBorrowedBookCount(It.IsAny<int>()), Times.Never);
            _notificationServiceMock.Verify(repo => repo.SendBorrowNotification(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
        }
        [Test]
        public void BorrowBook_WhenBookIsNotAvailable_ShouldReturnBookIsNotAvailable()
        {
            var member = new Member
            {
                MemberId = 1,
                MemberName = "John Doe",
                Email = "John@gmail.com",
                IsActive = true,
                BorrowedBookCount = 0,
                IsPremiumMember = false
            };
                var book = new Book
            {
                BookId = 2,
                BookTitle = "The Alchemist",
                AuthorName = "Paulo Coelho",
                IsAvailable = false
            };
            _memberRepositoryMock.Setup(repo => repo.GetMemberById(1))
                .Returns(member);
            _bookRepositoryMock.Setup(repo => repo.GetBookById(2))
                .Returns(book);
            var libraryService = new LibraryService(_bookRepositoryMock.Object, _memberRepositoryMock.Object, _notificationServiceMock.Object);
            var result = libraryService.BorrowBook(1, 2);
            Assert.That(result, Is.EqualTo("Book is not available"));
            _bookRepositoryMock.Verify(repo => repo.MarkBookAsBorrowed(It.IsAny<int>()), Times.Never);
            _memberRepositoryMock.Verify(repo => repo.UpdateBorrowedBookCount(It.IsAny<int>()), Times.Never);
            _notificationServiceMock.Verify(service => service.SendBorrowNotification(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
        }
        [Test]
        public void BorrowBook_WhenBorrowingLimitReached_ShouldReturnBorrowingLimitReached()
        {
            var member = new Member
            {
                MemberId = 3,
                MemberName = "Alice Smith",
                Email = "Alice@gmail.com",
                IsActive = true,
                BorrowedBookCount = 5
            };
            var book = new Book
            {
                BookId = 2,
                BookTitle = "The Alchemist",
                AuthorName = "Paulo Coelho",
                IsAvailable = true
            };
            _memberRepositoryMock.Setup(repo => repo.GetMemberById(3))
                .Returns(member);
            _bookRepositoryMock.Setup(repo => repo.GetBookById(2))
                .Returns(book);
            var libraryService = new LibraryService(_bookRepositoryMock.Object, _memberRepositoryMock.Object, _notificationServiceMock.Object);
            var result = libraryService.BorrowBook(3, 2);
            Assert.That(result, Is.EqualTo("Borrowing limit reached"));
            _bookRepositoryMock.Verify(repo => repo.MarkBookAsBorrowed(It.IsAny<int>()), Times.Never);
            _memberRepositoryMock.Verify(repo => repo.UpdateBorrowedBookCount(It.IsAny<int>()), Times.Never);
            _notificationServiceMock.Verify(service => service.SendBorrowNotification(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
        }
        [Test]
        public void BorrowBook_WhenMemberIdIsInvalid_ShouldReturnInvalidMemberId()
        {
            var libraryService = new LibraryService(_bookRepositoryMock.Object, _memberRepositoryMock.Object, _notificationServiceMock.Object);
            var result = libraryService.BorrowBook(-1, 1);
            Assert.That(result, Is.EqualTo("Invalid member id"));
            _bookRepositoryMock.Verify(repo => repo.GetBookById(It.IsAny<int>()), Times.Never);
            _memberRepositoryMock.Verify(repo => repo.GetMemberById(It.IsAny<int>()), Times.Never);
            _bookRepositoryMock.Verify(repo => repo.MarkBookAsBorrowed(It.IsAny<int>()), Times.Never);
            _memberRepositoryMock.Verify(repo => repo.UpdateBorrowedBookCount(It.IsAny<int>()), Times.Never);
            _notificationServiceMock.Verify(service => service.SendBorrowNotification(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
        }
        [Test]
        public void BorrowBook_WhenBookIdIsInvalid_ShouldReturnInvalidBookId()
        {
            var libraryService = new LibraryService(_bookRepositoryMock.Object, _memberRepositoryMock.Object, _notificationServiceMock.Object);
            var result = libraryService.BorrowBook(1, -1);
            Assert.That(result, Is.EqualTo("Invalid book id"));
            _bookRepositoryMock.Verify(repo => repo.GetBookById(It.IsAny<int>()), Times.Never);
            _memberRepositoryMock.Verify(repo => repo.GetMemberById(It.IsAny<int>()), Times.Never);
            _bookRepositoryMock.Verify(repo => repo.MarkBookAsBorrowed(It.IsAny<int>()), Times.Never);
            _memberRepositoryMock.Verify(repo => repo.UpdateBorrowedBookCount(It.IsAny<int>()), Times.Never);
            _notificationServiceMock.Verify(service => service.SendBorrowNotification(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
        }
        [Test]
        public void BorrowBook_WhenNormalMemberHasThreeBooks_ShouldReturnBorrowingLimitReached()
        {
            var member = new Member
            {
                MemberId = 4,
                MemberName = "Bob Johnson",
                Email = "Bob@gmail.com",
                IsActive = true,
                BorrowedBookCount = 3,
                IsPremiumMember = false
            };
            var book = new Book
            {
                BookId = 1,
                BookTitle = "The Alchemist",
                AuthorName = "Paulo Coelho",
                IsAvailable = true
            };
            _memberRepositoryMock.Setup(repo => repo.GetMemberById(4))
                .Returns(member);
            _bookRepositoryMock.Setup(repo => repo.GetBookById(1))
                .Returns(book);
            var libraryService = new LibraryService(_bookRepositoryMock.Object, _memberRepositoryMock.Object, _notificationServiceMock.Object);
            var result = libraryService.BorrowBook(4, 1);
            Assert.That(result, Is.EqualTo("Borrowing limit reached"));
            _bookRepositoryMock.Verify(repo => repo.MarkBookAsBorrowed(It.IsAny<int>()), Times.Never);
            _memberRepositoryMock.Verify(repo => repo.UpdateBorrowedBookCount(It.IsAny<int>()), Times.Never);
            _notificationServiceMock.Verify(service => service.SendBorrowNotification(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
        }
        [Test]
        public void BorrowBook_WhenPremiumMemberHasThreeBooks_ShouldAllowBorrowing()
        {
            var member = new Member
            {
                MemberId = 5,
                MemberName = "Charlie Brown",
                Email = "Charlie@gmail.com",
                IsActive = true,
                BorrowedBookCount = 3,
                IsPremiumMember = true
            };
            var book = new Book
            {
                BookId = 1,
                BookTitle = "Wings Of Fire",
                AuthorName = "Abdul kalam",
                IsAvailable = true
            };
            _memberRepositoryMock.Setup(repo => repo.GetMemberById(5))
                .Returns(member);
            _bookRepositoryMock.Setup(repo => repo.GetBookById(1))
                .Returns(book);
            var libraryService = new LibraryService(_bookRepositoryMock.Object, _memberRepositoryMock.Object, _notificationServiceMock.Object);
            var result = libraryService.BorrowBook(5, 1);
            Assert.That(result, Is.EqualTo("Book borrowed successfully"));
            _bookRepositoryMock.Verify(repo => repo.MarkBookAsBorrowed(1), Times.Once);
            _memberRepositoryMock.Verify(repo => repo.UpdateBorrowedBookCount(5), Times.Once);
            _notificationServiceMock.Verify(service => service.SendBorrowNotification("Charlie@gmail.com","Wings Of Fire"), Times.Once);
        }
        [Test]
        public void BorrowBook_WhenPremiumMemberHasFiveBooks_ShouldReturnBorrowingLimitReached()
        {
            var member = new Member
            {
                MemberId = 5,
                MemberName = "Charlie Brown",
                Email = "Charlie@gmail.com",
                IsActive = true,
                BorrowedBookCount = 6,
                IsPremiumMember = true
            };
            var book = new Book
            {
                BookId = 1,
                BookTitle = "Wings Of Fire",
                AuthorName = "Abdul kalam",
                IsAvailable = true
            };
            _memberRepositoryMock.Setup(repo => repo.GetMemberById(5))
                .Returns(member);
            _bookRepositoryMock.Setup(repo => repo.GetBookById(1))
                .Returns(book);
            var libraryService = new LibraryService(_bookRepositoryMock.Object, _memberRepositoryMock.Object, _notificationServiceMock.Object);
            var result = libraryService.BorrowBook(5, 1);
            Assert.That(result, Is.EqualTo("Borrowing limit reached"));
            _bookRepositoryMock.Verify(repo => repo.MarkBookAsBorrowed(It.IsAny<int>()), Times.Never);
            _memberRepositoryMock.Verify(repo => repo.UpdateBorrowedBookCount(It.IsAny<int>()), Times.Never);
            _notificationServiceMock.Verify(service => service.SendBorrowNotification(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
        }
    }
}
