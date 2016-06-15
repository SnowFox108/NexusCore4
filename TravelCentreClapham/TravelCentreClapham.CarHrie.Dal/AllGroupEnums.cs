using System.Runtime.Serialization;

namespace TravelCentreClapham.CarHrie.Dal
{
    public enum CarGroupType
    {
        [EnumMember(Value = "Small")]
        Small = 1
    }

    public enum GearType
    {
        [EnumMember(Value = "Manual")]
        Manual = 1,
        [EnumMember(Value = "Automatic")]
        Auto = 2,
        [EnumMember(Value = "Both")]
        Both = 3,
    }

    public enum FeulType
    {
        [EnumMember(Value = "Petrol")]
        Petrol = 1,
        [EnumMember(Value = "Diesel")]
        Diesel = 2,
    }

    public enum DealGroupType
    {
        [EnumMember(Value = "Standard")]
        Standard = 1,
        [EnumMember(Value = "Special Offer")]
        SpecialOffer = 2,
    }

    public enum DealExtraGroupType
    {
        [EnumMember(Value = "One Off")]
        OneOff = 1,
        [EnumMember(Value = "Per Day")]
        PerDay = 2,
    }

    public enum DiscountGroupType
    {
        [EnumMember(Value = "ManualEnter")]
        ManualEnter = 1,
        [EnumMember(Value = "Preset")]
        UsePreset = 2,
    }

    public enum DiscountValueGroupType
    {
        [EnumMember(Value = "Exact")]
        Exact = 1,
        [EnumMember(Value = "Percentage")]
        Percentage = 2,
    }

    public enum TransactionStatus
    {
        [EnumMember(Value = "Success")]
        Success = 1,
        [EnumMember(Value = "Reject")]
        Reject = 2,
    }

}
