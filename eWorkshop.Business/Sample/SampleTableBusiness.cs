using  XCommon.Patterns.Repository;
using eWorkshop.Data;
using eWorkshop.Data.Sample;
using eWorkshop.Entity.Sample;
using eWorkshop.Entity.Sample.Filter;
using System;

namespace eWorkshop.Business.Sample
{
    public class SampleTableBusiness: RepositoryEFBase<SampleTableEntity, SampleTableFilter, SampleTable, eWorkConext>
    {
    }
}
