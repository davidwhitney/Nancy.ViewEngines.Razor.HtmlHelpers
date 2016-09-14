using Nancy.ViewEngines.Razor.HtmlHelpersUnofficial;

namespace Nancy.ViewEngines.Razor.HtmlHelpers.Tests
{
    using Xunit;

    public class HtmlHelpersSelectExtensionsFixture
    {
        private TestModel model;
        private HtmlHelpers<TestModel> helpers;
        private string defaultOption;

        public HtmlHelpersSelectExtensionsFixture()
        {
            this.model = new TestModel { TestEnum = SelectListItemExtensionsFixture.TestEnum.Two };
            this.helpers = new HtmlHelpers<TestModel>(null, null, model);
            this.defaultOption = SelectListItemExtensionsFixture.TestEnum.Three.ToString();
        }

        [Fact]
        public void When_enum_provided_with_selected_value_value_is_selected_in_markup()
        {
            var items = model.TestEnum.ToSelectListItems(model.TestEnum);

            var output = helpers.DropDownListFor(x => x.TestEnum, defaultOption, items);

            Assert.Contains("<option selected=\"selected\" value=\"Two\">Two</option>", output.ToHtmlString());
        }

        [Fact]
        public void When_enum_provided_items_generated_from_enum()
        {
            var output = helpers.DropDownListFor(x => x.TestEnum, new {  });

            Assert.Contains("<select id=\"TestEnum\" name=\"TestEnum\">", output.ToHtmlString());
            Assert.Contains("<option selected=\"selected\" value=\"Two\">Two</option>", output.ToHtmlString());
        }

        public class TestModel
        {
            public SelectListItemExtensionsFixture.TestEnum TestEnum { get; set; }
        }
    }
}
