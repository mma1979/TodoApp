using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Shared;

public class Parent
{
    public  int Add(int x, int y)
    {
        return x + y;
    }
}

public class Child : Parent
{

    public int Add(int x, int y, int z)
    {
        return x + y;
    }

}

public   class MyClass
{
    public void Test()
    {
        var parent = new Parent();
        parent.Add(1, 2);

        var child = new Child();

        child.Add(1, 2);

        Parent p = new Child();

    }
}