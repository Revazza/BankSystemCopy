using BankSystem.Common.Db.Entities;
using BankSystem.InternetBank.Models.Requests;
using BankSystem.InternetBank.Repositories;
using BankSystem.InternetBank.Validations;

namespace InternetBank.Tests;

public class RegisterUserValidatorTests
{
    private readonly FakeBankSystemDbContext _db;
    private readonly UserRepository _userRepository;
    private RegisterUserRequest _validRequest;

    public RegisterUserValidatorTests()
    {
        _db = new FakeBankSystemDbContext();
        _userRepository = new UserRepository(_db);
    }
    [SetUp]
    public void SetUp()
    {
        _validRequest = new RegisterUserRequest
        {
            FirstName = "Ana",
            LastName = "Mk",
            PersonalNumber = "12345678901",
            Email = "Ana@example.com",
            Password = "string",
            BirthDate = DateTime.Parse("1990-01-01")
        };
        var user = new UserEntity()
        {
            FirstName = "Test",
            LastName = "Jolie",
            PersonalNumber = "14001027959",
            Email = "Angel@example.com",
            BirthDate = DateTime.Parse("1990-01-01"),
        };
        _db.Users.Add(user);
        _db.SaveChanges();
    }
    [Test]
    public void Validate_ValidRequest_DoesNotThrowException()
    {
        var validator = new RegisterUserValidator(_userRepository);
        TestDelegate action = () => validator.Validate(_validRequest);
        Assert.DoesNotThrow(action);
    }
    [Test]
    public void Validate_NullRequest_ThrowsArgumentNullException()
    {
        var validator = new RegisterUserValidator(_userRepository);
        TestDelegate action = () => validator.Validate(null);
        Assert.Throws<ArgumentNullException>(action);
    }

    [TestCase("ana123", "Last name must contain only letters")]
    [TestCase("123", "Last name must contain only letters")]
    public void Validate_InvalidLastName_ThrowsArgumentException(string lastName, string expectedErrorMessage)
    {
        
        var registrationService = new RegisterUserValidator(_userRepository);
        var invalidRequest = new RegisterUserRequest
        {
            FirstName = "Ana",
            LastName = lastName,
            PersonalNumber = "12345678901",
            Email = "ani@example.com",
            Password = "str",
            BirthDate = DateTime.Parse("1990-01-01")
        };

        TestDelegate action = () => registrationService.Validate(invalidRequest);

        var ex = Assert.Throws<ArgumentException>(action);
        Assert.AreEqual(expectedErrorMessage, ex.Message);
    }
    [Test]
    public void Validate_NullLastName_ThrowsArgumentException()
    {
        var registrationService = new RegisterUserValidator(_userRepository);
        var invalidRequest = new RegisterUserRequest
        {
            FirstName = "Ana",
            LastName = null,
            PersonalNumber = "12345678901",
            Email = "ani@example.com",
            Password = "str",
            BirthDate = DateTime.Parse("1990-01-01")
        };

        TestDelegate action = () => registrationService.Validate(invalidRequest);

        Assert.Throws<ArgumentNullException>(action);
      
    }
    [Test]
    public void Validate_NullFirstName_ThrowsArgumentException()
    {
        var registrationService = new RegisterUserValidator(_userRepository);
        var invalidRequest = new RegisterUserRequest
        {
            FirstName = null,
            LastName = "ana",
            PersonalNumber = "12345678901",
            Email = "ani@example.com",
            Password = "str",
            BirthDate = DateTime.Parse("1990-01-01")
        };

        TestDelegate action = () => registrationService.Validate(invalidRequest);

        Assert.Throws<ArgumentNullException>(action);
      
    }
    [TestCase("ana123","first name must contain only letters")]
    public void Validate_InvalidLFirstName_ThrowsArgumentException(string firstName, string expectedErrorMessage)
    {
        
        var registrationService = new RegisterUserValidator(_userRepository);
        var invalidRequest = new RegisterUserRequest
        {
            FirstName = firstName,
            LastName = "Mk",
            PersonalNumber = "12345678901",
            Email = "ani@example.com",
            Password = "str",
            BirthDate = DateTime.Parse("1990-01-01")
        };

        TestDelegate action = () => registrationService.Validate(invalidRequest);

        var ex = Assert.Throws<ArgumentException>(action);
        Assert.AreEqual(expectedErrorMessage, ex.Message);
    }
    [Test]
    public void Validate_NullPersonalNumber_ThrowsArgumentException()
    {
        var registrationService = new RegisterUserValidator(_userRepository);
        var invalidRequest = new RegisterUserRequest
        {
            FirstName = "ana",
            LastName = "ana",
            PersonalNumber = null,
            Email = "ani@example.com",
            Password = "str",
            BirthDate = DateTime.Parse("1990-01-01")
        };

        TestDelegate action = () => registrationService.Validate(invalidRequest);

        Assert.Throws<ArgumentNullException>(action);
      
    }
    [Test]
    public void Validate_NullEmail_ThrowsArgumentException()
    {
        var registrationService = new RegisterUserValidator(_userRepository);
        var invalidRequest = new RegisterUserRequest
        {
            FirstName = "ana",
            LastName = "ana",
            PersonalNumber = "12345678911",
            Email = null,
            Password = "str",
            BirthDate = DateTime.Parse("1990-01-01")
        };

        TestDelegate action = () => registrationService.Validate(invalidRequest);

        Assert.Throws<ArgumentNullException>(action);
      
    }
    
}