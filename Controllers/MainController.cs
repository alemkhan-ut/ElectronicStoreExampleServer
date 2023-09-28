using System.Numerics;
using ElectronicStoreServer.Data;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicStoreServer.Controllers
{
	[ApiController]
	[Route("api")]
	public class MainController : Controller
	{
		private ItemRepository _itemRepository;

		public MainController(ItemRepository itemRepository)
		{
			_itemRepository = itemRepository;
		}

		[HttpGet("phones")]
		[Produces("application/json")]
		public List<Phone> GetPhones()
		{
			return _itemRepository.Phones;
		}

		[HttpGet("phone/{id}")]
		[Produces("application/json")]
		public Phone GetPhone(int id)
		{
			return _itemRepository.Phones.First(phone => phone.Id == id);
		}

		[HttpGet("randomPhone")]
		[Produces("application/json")]
		public Phone GetRandomPhone()
		{
			Random random = new Random();

			return _itemRepository.Phones[random.Next(_itemRepository.Phones.Count)];
		}

		[HttpPost("postPhone")]
		[Produces("text/plain")]
		public IActionResult PostPhone([FromBody] Phone newPhone)
		{
			if (_itemRepository.Phones.Any(phone => phone.Model == newPhone.Model && phone.Brand == newPhone.Brand))
			{
				return BadRequest($"Бренд/Модель[{newPhone.Brand}/{newPhone.Model}], уже есть в базе");
			}

			newPhone.Id = _itemRepository.Phones.Last().Id + 1;

			_itemRepository.Phones.Add(newPhone);

			return Ok($"Телефон с [{newPhone.Id}] id создан");
		}

		[HttpPut("putPhone")]
		[Produces("application/json")]
		public IActionResult PutPhone([FromBody] Phone newPhone)
		{
			int indexToReplace = _itemRepository.Phones.FindIndex(phone => phone.Id == newPhone.Id);

			if (indexToReplace == -1)
			{
				return NotFound("Телефон не найден");
			}
			else
			{
				_itemRepository.Phones[indexToReplace] = newPhone;

				return Ok($"Телефон с [{_itemRepository.Phones[indexToReplace].Id}] id обновлён");
			}
		}

		[HttpPut("resetPhones")]
		[Produces("text/plain")]
		public IActionResult ResetPhones()
		{
			_itemRepository.ResetPhones();

			return Ok("Список телефонов установлено по умолчанию");
		}

		[HttpDelete("deletePhone/{id}")]
		[Produces("application/json")]
		public IActionResult DeletePhone(int id)
		{
			Phone? targetPhone = _itemRepository.Phones.FirstOrDefault(phone => phone.Id == id);

			if (targetPhone is null)
			{
				return NotFound("Телефон не найден");
			}
			else
			{
				_itemRepository.Phones.Remove(targetPhone);

				return Ok($"Телефон с [{id}] id удален");
			}
		}
	}
}