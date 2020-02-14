using System;

namespace JavaCompiler
{
    public class JavaCompileAndRun
    {
        public JavaCompileAndRun(string code,string classname)
        {
            var manage = new ManageJavaFileSystem(code,classname);
            manage.run();

        }
    }
}
