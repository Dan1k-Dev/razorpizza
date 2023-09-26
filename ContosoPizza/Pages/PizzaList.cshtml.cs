using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ConstosoPizza.Pages
{
    public class PizzaListModel : PageModel
    {
        private readonly PizzaService _service;
        public IList<Pizza> PizzaList { get; set; } = default!;

        public PizzaListModel(PizzaService service)
        {
            _service = service;
        }

        /// <summary>
        /// Получение списка пицц
        /// </summary>
        public void OnGet()
        {
            PizzaList = _service.GetPizzas();
        }

        [BindProperty]
        public Pizza NewPizza { get; set; } = default!;

        /// <summary>
        /// Обработчик страницы для добавления пиццы в существующий списка
        /// </summary>
        /// <returns>Страница со списком пицц</returns>
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid || NewPizza == null)
            {
                return Page();
            }
            _service.AddPizza(NewPizza);
            return RedirectToAction("Get");
        }

        /// <summary>
        /// Обработчик страницы для удаления пиццы из существующего списка
        /// </summary>
        /// <param name="id">Удаление по параметру id</param>
        /// <returns>Get запрос </returns>
        public IActionResult OnPostDelete(int id)
        {
            _service.DeletePizza(id);
            return RedirectToAction("Get");
        }
    }
}
