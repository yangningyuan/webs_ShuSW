
namespace Common.LigerGrid
{
    public class ViewInfo
    {
        public ViewInfo(string viewname, string keyname)
        {
            ViewName = viewname;
            KeyName = keyname;
        }
        public string ViewName { get; set; }
        public string KeyName { get; set; }
        public string Description { get; set; }
    }
}
