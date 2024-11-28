[Test(Ignore="Depends on issue #193 to work")]
void Foo() {}

[Test(Ignore="Depends on issue #193 to work")]
void Bar() {}

[Test(Name="Foo", Ignore="This should match #193")]


Test(
Ignore="Depends on issue #193 to work")
This is a fale positive..

[Test(IgnoreNao="Another falsde positive for #193")]


[Ignore("bla bla #193 bla bla")]
void FooBar() {}

void FooBar() {
    var x = IgnoreReason="do not works.. #193 bla bla"; 
}