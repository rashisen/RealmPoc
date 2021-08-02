using System;
using System.Collections.Generic;
using MongoDB.Bson;
using Realms;
using Realms.Schema;

public class GuitarDTO : RealmObject
{
        [PrimaryKey]
        public Guid Id { get; set; }
        [Required]
        public string Make { get; set; }
        [Required]
        public string Model { get; set; }
        public double Price { get; set; }
        public string Owner { get; set; }
        public new bool IsManaged { get;}
        public new RealmObjectBase.Dynamic DynamicApi { get; }
        public new bool IsValid { get;}
        public new bool IsFrozen { get;}
        public new Realm Realm { get; }
        public new ObjectSchema ObjectSchema { get; }
        public new int BacklinksCount { get; }

    public override bool Equals(object obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override string ToString()
    {
        return base.ToString();
    }

    protected override void OnManaged()
    {
        base.OnManaged();
    }

    protected override void OnPropertyChanged(string propertyName)
    {
        base.OnPropertyChanged(propertyName);
    }
    
}