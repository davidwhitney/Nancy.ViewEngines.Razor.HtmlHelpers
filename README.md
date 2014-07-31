Nancy.ViewEngines.Razor.HtmlHelpers
===================================

A port of the ASP.NET MVC Razor helpers to #NancyFx

This is going to be a little rough around the edges for awhile - I've cleved these straight out of the MVC codebase AND a closed source project.

Mostly here to remove some of the friction of binding up UI models with magic strings - the helpers along wth Expressions over the models help refactoring, and removed a good deal of frustraition from a project I'm working on. I'm now going back and "completing the job".

Due to the hack-and-slash port of this code there aren't any tests right now - I'll be working on that shortly - right now, it kind of "just about works" - but might be useful to people.

# Getting started

Add:

    @using Nancy.ViewEngines.Razor.HtmlHelpers;
  
to your Razor views. You can probably do a web/app.config namespace import too.

Use:

    @Html.TextBoxFor(x=>x.YourProperty)
    
To render a TextBox with valid Ids and values.

# Roadmap

* Html.InputThing("stringName", "value") string helpers for all common form inputs
* Html.InputThing(x=>x.MyProperty) Expression helpers for all common form inputs
* Something that resembles tests
* Better docs
* Model state validation (currently entirely removed)

# Copyrights

Currently some of the code in here is ripped right out of the ASP.NET MVC codebase - it'll be gradually re-written as I'm not fond of it - and probably don't have the right to redistribute it yet. They're probably not going to come get us if you use this in the meantime ;)