[Test(Ignore="Depends on issue #194 to work")]
void Foo() {}

[Test(Ignore="Depends on issue #194 to work")]
void Bar() {}

[Test(Name="Foo", Ignore="This should match #194")]


Test(
Ignore="Depends on issue #194 to work")
This is a fale positive..

[Test(IgnoreNao="Another falsde positive for #194")]


[Ignore("bla bla #194 bla bla")]
void FooBar() {}

void FooBar() {
    var x = IgnoreReason="do not works.. #194 bla bla";
}