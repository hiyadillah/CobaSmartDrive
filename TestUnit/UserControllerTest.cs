using Bogus;
using Domain.DTO;
using Domain.Entities;
using Domain.Repository.Base;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WebAPI.Controllers;

namespace TestUnit
{
    public class UserControllerTest
    {
        private readonly Mock<IRepositoryEntityBase<User, UserRequest>> _mock;
        private readonly UserController _controller;
        private readonly List<User> items=new();

        public UserControllerTest()
        {
            _mock = new Mock<IRepositoryEntityBase<User, UserRequest>>();
            _controller = new UserController(_mock.Object);
            var faker = new Faker("en");
            for (int i = 1; i <= 10; i++)
            {
                items.Add(new User { UserID = i,Username= faker.Name.FirstName(),Password= faker.Random.Word() });
            }
        }

        [Fact]
        public async void Get_User_ShouldReturnAllUser()
        {
            _mock.Setup(s=>s.GetAll()).ReturnsAsync(items);
            var actionResult=await _controller.Get();
            var result=actionResult.Result as OkObjectResult;
            var value = result!.Value as IEnumerable<User>;

            Assert.IsType<OkObjectResult>(result);
            Assert.IsAssignableFrom<IEnumerable<User>>(value);
            Assert.Equal(value!, items);
        }
        [Fact]
        public async void GetById_User_ShouldReturnUser()
        {
            var item = items.First();
            _mock.Setup(s => s.GetById(1)).ReturnsAsync(item);
            var actionResult = await _controller.GetById(1);
            var result = actionResult.Result as OkObjectResult;
            var value = result!.Value as User;

            Assert.IsType<OkObjectResult>(result);
            Assert.IsAssignableFrom<User>(value);
            Assert.Equal(value!, item);
        }
        [Fact]
        public async void Create_User_ShouldCreateUser()
        {
            var item = items.First();
            _mock.Setup(s => s.Create(item.Adapt<UserRequest>())).ReturnsAsync(item);
            var actionResult = await _controller.Create(item.Adapt<UserRequest>());
            var result = actionResult.Result as CreatedAtActionResult;
            var value = result!.Value as User;

            Assert.IsType<CreatedAtActionResult>(result);
            Assert.IsAssignableFrom<User>(value);
            Assert.Equal(value!, item);
        }
        [Fact]
        public async void Update_User_ShouldUpdateUser()
        {
            var item = items.First();
            _mock.Setup(s => s.Update(1, item.Adapt<UserRequest>()));
            var actionResult = await _controller.Update(1, item.Adapt<UserRequest>());

            Assert.IsType<NoContentResult>(actionResult);
        }
        [Fact]
        public async void Delete_User_ShouldDeleteUser()
        {
            var item = items.First();
            _mock.Setup(s => s.Delete(1));
            var actionResult = await _controller.Delete(1);

            Assert.IsType<NoContentResult>(actionResult);
        }
    }
}