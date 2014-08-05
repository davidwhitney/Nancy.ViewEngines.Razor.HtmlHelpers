Nancy.ViewEngines.Razor.HtmlHelpers
===================================
_A port of the ASP.NET MVC Razor helpers to #NancyFx_

---

* Configuration
* Usage
* Roadmap
* Contributing
* Copyright


This is a rough port of the ASP.NET MVC HTML Helpers to NancyFx's Razor implementation.

Currently an un-tested hack-and-slash port of this code - I'll be working on that shortly - right now, it kind of "just about works" - and might help people.

There will be packages on NuGet as soon as all the basic helpers and Begin/Endform are ported.

## Configuration

Add:

```c#
    @using Nancy.ViewEngines.Razor.HtmlHelpers;
```
  
to your Razor views. You can probably do a web/app.config namespace import too.

## Usage

```c#
    @using System.Collections.Generic
    @using Nancy.ViewEngines.Razor.HtmlHelpers
    @inherits Nancy.ViewEngines.Razor.NancyRazorViewBase<Nancy.ViewEngines.Razor.HtmlHelpers.TestApp.Model>

    @Html.TextBoxFor(x=>x.AString)
    @Html.TextBoxFor(x=>x.ABool)
    @Html.TextBoxFor(x=>x.AnInt)
    @Html.TextBoxFor(x=>x.EnumerableInts)
    @Html.TextBoxFor(x=>x.ListOfStrings)
    @Html.TextBoxFor(x=>x.NullableInt)
    @Html.TextBoxFor(x => x.AString, new { myAttribute = "isAwesome" })
    @Html.TextBox("TextBoxName", "TBValue")
    @Html.HiddenFor(x => x.AString)
    @Html.HiddenFor(x => x.ABool)
    @Html.HiddenFor(x => x.AnInt)
    @Html.HiddenFor(x => x.EnumerableInts)
    @Html.HiddenFor(x => x.ListOfStrings)
    @Html.HiddenFor(x => x.NullableInt)
    @Html.HiddenFor(x => x.AString, new { myAttribute = "isAwesome" })
    @Html.Hidden("HiddenTextBoxName", "TBValue")
    @Html.PasswordFor(x => x.AString)
    @Html.PasswordFor(x => x.ABool)
    @Html.PasswordFor(x => x.AnInt)
    @Html.PasswordFor(x => x.EnumerableInts)
    @Html.PasswordFor(x => x.ListOfStrings)
    @Html.PasswordFor(x => x.NullableInt)          
    @Html.PasswordFor(x => x.AString, new { myAttribute = "isAwesome" })
    @Html.Password("PasswordTextBoxName", "TBValue")
    @Html.TextAreaFor(x => x.AString)          
    @Html.TextAreaFor(x => x.AString, new { myAttribute = "isAwesome" })
    @Html.TextArea("TextAreaFor", "TBValue")
    @Html.CheckBox("CheckBoxName")
    @Html.CheckBoxFor(x=>x.ABool)
    @Html.CheckBoxFor(x=>x.ABool, true)
    @Html.CheckBoxFor(x=>x.ABool, false)
    @Html.CheckBoxFor(x=>x.ABool, true, new { myAttribute = "isAwesome" })
    @Html.LabelFor(x => x.AString)
    @Html.LabelFor(x => x.ABool)
    @Html.LabelFor(x => x.AnInt)
    @Html.LabelFor(x => x.EnumerableInts)
    @Html.LabelFor(x => x.ListOfStrings)
    @Html.LabelFor(x => x.NullableInt)
    @Html.LabelFor(x => x.AString, new { myAttribute = "isAwesome" })
    @Html.Label("TextBoxName", "TBValue")
    @Html.ListBoxFor(x=>x.EnumerableInts, new List<SelectListItem>{new SelectListItem("some text", "value"), new SelectListItem("some text (this'll select)", "value", true)})
    @Html.ListBoxFor(x=>x.EnumerableInts, new List<SelectListItem>{new SelectListItem("some text", "value"), new SelectListItem("some text (this'll select)", "value", true)}, new {}, 1, false)
    @Html.DropDownListFor(x=>x.EnumerableInts, new List<SelectListItem>{new SelectListItem("some text", "value"), new SelectListItem("some text (this'll select)", "value", true)})
```    

## Roadmap

* Complete port of Html.InputThing("stringName", "value") string helpers for all common form inputs
* Complete port of Html.InputThing(x=>x.MyProperty) Expression helpers for all common form inputs
* Port of BeginForm and EndForm
* Something that resembles tests
* Support for ModelMetadata and attribute overloads for DisplayName and other Attributes
* Model state validation (currently entirely removed)

Begin and End form will likely be very different than their MVC counterparts, while the rest of the markup helpers remain almost identical. This is because of the difference in routing between the two frameworks.

Validation helpers are going to take some work because the MVC code extensively uses ModelState - which is entirely an ASP.NET MVC construct and doesn't exist in NancyFx.

## Contributing

Please please please contribute.
This is currently a very thin port - I had to strip out lots of the logic related to mapping attributes due to their deep links into the guts of MVC. Regardless, the DataAnnotations are nice features, and I'd like to preserve them if I can.

## Copyright

Portions of this codebase are derived from the ASP.NET MVC4 codebase - which is licensed under the Apache License.
Any Nancy bits are licensed under the terms of that framework.

Any original work is also licensed under the Apache License.

Licensed under the Apache License, Version 2.0 (the "License"). You
may not use this file except in compliance with the License. A copy of
the License is located in the LICENSE file in this repository. 

This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
CONDITIONS OF ANY KIND, either express or implied. See the License 
for the specific language governing permissions and limitations under 
the License.
