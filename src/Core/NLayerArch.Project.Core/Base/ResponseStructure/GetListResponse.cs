using NLayerArch.Project.Bussines.Base.PagingStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerArch.Project.Bussines.Base.ResponseStructure
{
    public class GetListResponse<T> : BasePageableModel
    {
        public IList<T> Items
        {
            get => _items ??= new List<T>();
            set => _items = value;
        }

        private IList<T>? _items;
    }
}
