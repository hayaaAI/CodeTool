using System;
using System.Reflection;
/// <summary>
/// 根据服务类定义程序集生成主要sql脚本以及数据库表创建脚本
/// </summary>
namespace AutoCodeTool
{
    class Program
    {
        /// <summary>
        /// 只需要一个包含文件后缀的文件路径
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

            //if (args == null)
            //{
            //    Console.WriteLine("请输入文件路径");
            //    return;
            //}
            //if (args.Length == 0)
            //{
            //    Console.WriteLine("请输入文件路径");
            //    return;
            //}
            //String filePath = args[0];
            String basePath = @"C:\Users\windwolf\.nuget\packages\hayaa.basemodel\1.0.0.2\lib\netcoreapp2.0\Hayaa.BaseModel.dll";
            Assembly asemblyBase = Assembly.LoadFile(basePath);
            String filePath = @"D:\project\HayaaAI\CodeTool\Hayaa.AutoCode\Hayaa.ModelService\bin\Debug\netcoreapp2.0\Hayaa.ModelService.dll";
            //载入程序集
            Assembly asembly = Assembly.LoadFile(filePath);
            //获取程序集中所有的类和接口
            Type[] types = asembly.GetTypes();            
            foreach(var type in types)
            {
                
            }
            Console.WriteLine("转换完毕,按任意键结束");
            Console.ReadKey();
        }
    }
}
