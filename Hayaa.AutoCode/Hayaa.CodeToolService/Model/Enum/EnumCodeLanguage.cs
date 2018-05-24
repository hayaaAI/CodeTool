using System;
namespace Hayaa.CodeToolService
{
    /// <summary>
    /// 编程语言
    /// 一个模板可能会多语言编程
    /// </summary>
    [Flags]
    public enum CodeLanaguage
    {
        CSharp = 1,
        Java = 2,
        FSharp = 4,
        Go = 8,
        Python = 16,
        MS_Sql = 32,
        MySQl_Sql = 64,
        Html = 128,
        Javascript = 256,
        QSharp = 512,
    }
}
