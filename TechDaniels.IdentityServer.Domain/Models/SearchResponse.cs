using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechDaniels.IdentityServer.Domain.Base;

namespace TechDaniels.IdentityServer.Domain.Models
{
    public class SearchResponse<DTO>
        where DTO : BaseDTO
    {
        public int Count {  get; set; }
        public IEnumerable<DTO> List {  get; set; }

        public static SearchResponse<DTO> Build(int count,  IEnumerable<DTO> list) =>
            new SearchResponse<DTO>() { Count = count, List = list };
    }
}
