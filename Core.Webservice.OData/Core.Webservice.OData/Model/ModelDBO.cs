using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Client.OData.Model
{
    public class ODataTable1
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public ICollection<ODataTable2> ODataTable2List { get; set; }
    }

    public class ODataTable2
    {
        public Guid Id { get; set; }
        public string Value { get; set; }

        [ForeignKey("ODataTable1")]
        public Guid ODataTable1Id { get; set; }

        public ODataTable1 ODataTable1 { get; set; }
    }
}