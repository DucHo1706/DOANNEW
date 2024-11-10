using DOANNEW.Models;
using System.Web.Mvc;

namespace DOANNEW.Controllers
{
    public interface ITrangChuController
    {
        ActionResult Create();
        ActionResult Create([Bind(Include = "BaiVietID,TieuDe,NoiDung,DanhMucID,Hinh_Anh,UserID")] Bai_viet bai_viet);
        ActionResult Delete(int? id);
        ActionResult DeleteConfirmed(int id);
        ActionResult Details(int? id);
        ActionResult Edit([Bind(Include = "BaiVietID,TieuDe,NoiDung,DanhMucID,Hinh_Anh,UserID")] Bai_viet bai_viet);
        ActionResult Edit(int? id);
        ActionResult Index();
    }
}