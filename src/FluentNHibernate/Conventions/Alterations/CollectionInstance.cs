using FluentNHibernate.Conventions.Alterations.Instances;
using FluentNHibernate.Conventions.Inspections;
using FluentNHibernate.MappingModel.Collections;

namespace FluentNHibernate.Conventions.Alterations
{
    public class CollectionInstance : CollectionInspector, ICollectionInstance
    {
        private readonly ICollectionMapping mapping;

        public CollectionInstance(ICollectionMapping mapping)
            : base(mapping)
        {
            this.mapping = mapping;
        }

        public new IKeyInstance Key
        {
            get { return new KeyInstance(mapping.Key); }
        }

        IRelationshipAlteration ICollectionAlteration.Relationship
        {
            get { return Relationship; }
        }

        public IRelationshipInstance Relationship
        {
            get { return new RelationshipInstance(mapping.Relationship); }
        }

        IKeyAlteration ICollectionAlteration.Key
        {
            get { return Key; }
        }

        public void SetTableName(string tableName)
        {
            mapping.TableName = tableName;
        }

        public void Name(string name)
        {
            mapping.Name = name;
        }
    }
}