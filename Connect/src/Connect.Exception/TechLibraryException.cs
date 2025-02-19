using System;
using System.Net;

namespace Connect.Exception;

public abstract class TechLibraryException : SystemException
{
public abstract List<string> GetErrorMessages();
public abstract HttpStatusCode GetStatusCode();
}
