// create a style list by the empty ctor or like this; the third (bool) parameter is optional
var list = StyleList.Create("background-color", "red");

// add styles like this; here the third parameter is also optional (true by default)
list.Add("opacity", "0", IsHidden);

// style list is commonly used like this
public string CssStyle => StyleList.Create("background-color", "red")
                                   .Add("opacity", "0", IsHidden);

// the resulting style for a non-hidden state would be 'background-color:red'