using System.Numerics;
using ElectronicStoreServer.Data;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicStoreServer.Controllers
{
	[ApiController]
	[Route("api")]
	public class MainController : Controller
	{
		private List<Phone> _phones = new List<Phone>()
		{
			new Phone { Id = 0, Brand = "Apple", Model = "iPhone 12", Price = 899.99, Memory = 64, RAM = 4, OperationSystem = "iOS", Processor = "A14 Bionic", Amount = 6 },
			new Phone { Id = 1, Brand = "Apple", Model = "iPhone 13", Price = 999.99, Memory = 128, RAM = 6, OperationSystem = "iOS", Processor = "A15 Bionic", Amount = 23 },
			new Phone { Id = 2, Brand = "Apple", Model = "iPhone SE (2020)", Price = 399.99, Memory = 64, RAM = 3, OperationSystem = "iOS", Processor = "A13 Bionic", Amount = 63 },
			new Phone { Id = 3, Brand = "Asus", Model = "ROG Phone 5", Price = 1099.99, Memory = 256, RAM = 16, OperationSystem = "ROG UI", Processor = "Snapdragon 888", Amount = 67 },
			new Phone { Id = 4, Brand = "Asus", Model = "ZenFone 6", Price = 399.99, Memory = 64, RAM = 6, OperationSystem = "ZenUI", Processor = "Snapdragon 855", Amount = 54 },
			new Phone { Id = 5, Brand = "Asus", Model = "ZenFone 7", Price = 599.99, Memory = 128, RAM = 6, OperationSystem = "ZenUI", Processor = "Snapdragon 865+", Amount = 16 },
			new Phone { Id = 6, Brand = "Google", Model = "Pixel 4a", Price = 349.99, Memory = 128, RAM = 6, OperationSystem = "Android", Processor = "Snapdragon 730G", Amount = 1 },
			new Phone { Id = 7, Brand = "Google", Model = "Pixel 5", Price = 699.99, Memory = 128, RAM = 8, OperationSystem = "Android", Processor = "Snapdragon 765G", Amount = 0 },
			new Phone { Id = 8, Brand = "Google", Model = "Pixel 6", Price = 699.99, Memory = 128, RAM = 8, OperationSystem = "Android", Processor = "Google Tensor", Amount = 54 },
			new Phone { Id = 9, Brand = "Huawei", Model = "Mate 40 Pro", Price = 899.99, Memory = 256, RAM = 8, OperationSystem = "EMUI", Processor = "Kirin 9000", Amount = 12 },
			new Phone { Id = 10, Brand = "Huawei", Model = "P30 Lite", Price = 249.99, Memory = 128, RAM = 4, OperationSystem = "EMUI", Processor = "Kirin 710", Amount = 74 },
			new Phone { Id = 11, Brand = "Huawei", Model = "P40 Pro", Price = 899.99, Memory = 256, RAM = 8, OperationSystem = "EMUI", Processor = "Kirin 990", Amount = 23 },
			new Phone { Id = 12, Brand = "LG", Model = "G8 ThinQ", Price = 499.99, Memory = 128, RAM = 6, OperationSystem = "Android", Processor = "Snapdragon 855", Amount = 0 },
			new Phone { Id = 13, Brand = "LG", Model = "K92 5G", Price = 299.99, Memory = 128, RAM = 6, OperationSystem = "Android", Processor = "Snapdragon 690", Amount = 65 },
			new Phone { Id = 14, Brand = "LG", Model = "V60 ThinQ", Price = 699.99, Memory = 128, RAM = 8, OperationSystem = "Android", Processor = "Snapdragon 865", Amount = 0 },
			new Phone { Id = 15, Brand = "OnePlus", Model = "8T", Price = 799.99, Memory = 128, RAM = 8, OperationSystem = "OxygenOS", Processor = "Snapdragon 865", Amount = 12 },
			new Phone { Id = 16, Brand = "OnePlus", Model = "9 Pro", Price = 899.99, Memory = 256, RAM = 12, OperationSystem = "OxygenOS", Processor = "Snapdragon 888", Amount = 10 },
			new Phone { Id = 17, Brand = "OnePlus", Model = "Nord N10", Price = 299.99, Memory = 128, RAM = 6, OperationSystem = "OxygenOS", Processor = "Snapdragon 690", Amount = 7 },
			new Phone { Id = 18, Brand = "Oppo", Model = "A54", Price = 249.99, Memory = 64, RAM = 4, OperationSystem = "ColorOS", Processor = "MediaTek Helio P35", Amount = 5 },
			new Phone { Id = 19, Brand = "Oppo", Model = "Find X3 Pro", Price = 899.99, Memory = 256, RAM = 12, OperationSystem = "ColorOS", Processor = "Snapdragon 888", Amount = 0 },
			new Phone { Id = 20, Brand = "Oppo", Model = "Reno 5 Pro", Price = 699.99, Memory = 128, RAM = 8, OperationSystem = "ColorOS", Processor = "Dimensity 1000+", Amount = 63 },
			new Phone { Id = 21, Brand = "Samsung", Model = "Galaxy A52", Price = 349.99, Memory = 128, RAM = 6, OperationSystem = "Android", Processor = "Snapdragon 720G", Amount = 6 },
			new Phone { Id = 22, Brand = "Samsung", Model = "Galaxy Note 20", Price = 899.99, Memory = 256, RAM = 8, OperationSystem = "Android", Processor = "Exynos 990", Amount = 9 },
			new Phone { Id = 23, Brand = "Samsung", Model = "Galaxy S21", Price = 799.99, Memory = 256, RAM = 8, OperationSystem = "Android", Processor = "Exynos 2100", Amount = 23 },
			new Phone { Id = 24, Brand = "Sony", Model = "Xperia 1 III", Price = 1199.99, Memory = 256, RAM = 12, OperationSystem = "Android", Processor = "Snapdragon 888", Amount = 53 },
			new Phone { Id = 25, Brand = "Sony", Model = "Xperia 5 II", Price = 799.99, Memory = 128, RAM = 8, OperationSystem = "Android", Processor = "Snapdragon 865", Amount = 0 },
			new Phone { Id = 26, Brand = "Sony", Model = "Xperia L4", Price = 199.99, Memory = 64, RAM = 3, OperationSystem = "Android", Processor = "MediaTek Helio P22", Amount = 5 },
			new Phone { Id = 27, Brand = "Xiaomi", Model = "Mi 10", Price = 699.99, Memory = 256, RAM = 8, OperationSystem = "MIUI", Processor = "Snapdragon 865", Amount = 34 },
			new Phone { Id = 28, Brand = "Xiaomi", Model = "Mi 11 Ultra", Price = 1099.99, Memory = 512, RAM = 12, OperationSystem = "MIUI", Processor = "Snapdragon 888", Amount = 74 },
			new Phone { Id = 29, Brand = "Xiaomi", Model = "Redmi Note 10 Pro", Price = 249.99, Memory = 128, RAM = 6, OperationSystem = "MIUI", Processor = "Snapdragon 732G", Amount = 0 },
		};

		[HttpGet("phones")]
		[Produces("application/json")]
		public List<Phone> GetPhones()
		{
			return _phones;
		}

		[HttpGet("phone/{id}")]
		[Produces("application/json")]
		public Phone GetPhone(int id)
		{
			return _phones.First(phone => phone.Id == id);
		}

		[HttpGet("randomPhone")]
		[Produces("application/json")]
		public Phone GetRandomPhone()
		{
			Random random = new Random();

			return _phones[random.Next(_phones.Count)];
		}

		[HttpPost("postPhone")]
		[Produces("text/plain")]
		public IActionResult PostPhone([FromBody] Phone newPhone)
		{
			if (_phones.Any(phone => phone.Model == newPhone.Model && phone.Brand == newPhone.Brand))
			{
				return BadRequest($"Бренд/Модель[{newPhone.Brand}/{newPhone.Model}], уже есть в базе");
			}

			newPhone.Id = _phones.Last().Id + 1;

			_phones.Add(newPhone);

			return Ok($"Телефон с [{newPhone.Id}] id создан");
		}

		[HttpPut("putPhone")]
		[Produces("text/plain")]
		public IActionResult PutPhone([FromBody] Phone newPhone)
		{
			Phone? targetPhone = _phones.FirstOrDefault(phone => phone.Id == newPhone.Id);

			if (targetPhone is null)
			{
				return NotFound("Телефон не найден");
			}
			else
			{
				targetPhone = newPhone;

				return Ok($"Телефон с [{newPhone.Id}] id обновлён");
			}
		}

		[HttpDelete("deletePhone/{id}")]
		[Produces("application/json")]
		public IActionResult DeletePhone(int id)
		{
			Phone? targetPhone = _phones.FirstOrDefault(phone => phone.Id == id);

			if (targetPhone is null)
			{
				return NotFound("Телефон не найден");
			}
			else
			{
				_phones.Remove(targetPhone);

				return Ok($"Телефон с [{id}] id удален");
			}
		}
	}
}