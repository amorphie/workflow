using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Refit;

public class ClientFactory
{
    public ICallSerciveAPI CreateClient(string url) => RestService.For<ICallSerciveAPI>(url);
}