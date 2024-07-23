// create a class list by the empty ctor or like this; the second (bool) parameter is optional
var list = ClassList.Create("my-class");

// add classes like this; here the second parameter is also optional (true by default)
list.Add("disabled", IsDisabled);

// class list is commonly used like this
public string CssClass => ClassList.Create("my-class")
                                   .Add("active", IsActive)
                                   .Add("disabled", IsDisabled);

// the resulting class for a non-active, disabled state would be 'my-class disabled'