using System;
using System.IO;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using ChargeBee.Internal;
using ChargeBee.Api;
using ChargeBee.Models.Enums;
using ChargeBee.Filters.Enums;

namespace ChargeBee.Models
{

    public class CreditNoteEstimate : Resource 
    {
    

        #region Methods
        #endregion
        
        #region Properties
        public string ReferenceInvoiceId 
        {
            get { return GetValue<string>("reference_invoice_id", true); }
        }
        public TypeEnum CreditNoteEstimateType 
        {
            get { return GetEnum<TypeEnum>("type", true); }
        }
        public PriceTypeEnum PriceType 
        {
            get { return GetEnum<PriceTypeEnum>("price_type", true); }
        }
        public string CurrencyCode 
        {
            get { return GetValue<string>("currency_code", true); }
        }
        public int SubTotal 
        {
            get { return GetValue<int>("sub_total", true); }
        }
        public int Total 
        {
            get { return GetValue<int>("total", true); }
        }
        public int AmountAllocated 
        {
            get { return GetValue<int>("amount_allocated", true); }
        }
        public int AmountAvailable 
        {
            get { return GetValue<int>("amount_available", true); }
        }
        public List<CreditNoteEstimateLineItem> LineItems 
        {
            get { return GetResourceList<CreditNoteEstimateLineItem>("line_items"); }
        }
        public List<CreditNoteEstimateDiscount> Discounts 
        {
            get { return GetResourceList<CreditNoteEstimateDiscount>("discounts"); }
        }
        public List<CreditNoteEstimateTax> Taxes 
        {
            get { return GetResourceList<CreditNoteEstimateTax>("taxes"); }
        }
        public List<CreditNoteEstimateLineItemTax> LineItemTaxes 
        {
            get { return GetResourceList<CreditNoteEstimateLineItemTax>("line_item_taxes"); }
        }
        public List<CreditNoteEstimateLineItemDiscount> LineItemDiscounts 
        {
            get { return GetResourceList<CreditNoteEstimateLineItemDiscount>("line_item_discounts"); }
        }
        public List<CreditNoteEstimateLineItemTier> LineItemTiers 
        {
            get { return GetResourceList<CreditNoteEstimateLineItemTier>("line_item_tiers"); }
        }
        public int? RoundOffAmount 
        {
            get { return GetValue<int?>("round_off_amount", false); }
        }
        public string CustomerId 
        {
            get { return GetValue<string>("customer_id", false); }
        }
        
        #endregion
        

        public enum TypeEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [EnumMember(Value = "adjustment")]
            Adjustment,
            [EnumMember(Value = "refundable")]
            Refundable,

        }

        #region Subclasses
        public class CreditNoteEstimateLineItem : Resource
        {
            public enum EntityTypeEnum
            {
                UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
                [EnumMember(Value = "plan_setup")]
                PlanSetup,
                [EnumMember(Value = "plan")]
                Plan,
                [EnumMember(Value = "addon")]
                Addon,
                [EnumMember(Value = "adhoc")]
                Adhoc,
            }

            public string Id() {
                return GetValue<string>("id", false);
            }

            public string SubscriptionId() {
                return GetValue<string>("subscription_id", false);
            }

            public DateTime DateFrom() {
                return (DateTime)GetDateTime("date_from", true);
            }

            public DateTime DateTo() {
                return (DateTime)GetDateTime("date_to", true);
            }

            public int UnitAmount() {
                return GetValue<int>("unit_amount", true);
            }

            public int? Quantity() {
                return GetValue<int?>("quantity", false);
            }

            public int? Amount() {
                return GetValue<int?>("amount", false);
            }

            public PricingModelEnum? PricingModel() {
                return GetEnum<PricingModelEnum>("pricing_model", false);
            }

            public bool IsTaxed() {
                return GetValue<bool>("is_taxed", true);
            }

            public int? TaxAmount() {
                return GetValue<int?>("tax_amount", false);
            }

            public double? TaxRate() {
                return GetValue<double?>("tax_rate", false);
            }

            public int? DiscountAmount() {
                return GetValue<int?>("discount_amount", false);
            }

            public int? ItemLevelDiscountAmount() {
                return GetValue<int?>("item_level_discount_amount", false);
            }

            public string Description() {
                return GetValue<string>("description", true);
            }

            public EntityTypeEnum EntityType() {
                return GetEnum<EntityTypeEnum>("entity_type", true);
            }

            public TaxExemptReasonEnum? TaxExemptReason() {
                return GetEnum<TaxExemptReasonEnum>("tax_exempt_reason", false);
            }

            public string EntityId() {
                return GetValue<string>("entity_id", false);
            }

            public string CustomerId() {
                return GetValue<string>("customer_id", false);
            }

        }
        public class CreditNoteEstimateDiscount : Resource
        {
            public enum EntityTypeEnum
            {
                UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
                [EnumMember(Value = "item_level_coupon")]
                ItemLevelCoupon,
                [EnumMember(Value = "document_level_coupon")]
                DocumentLevelCoupon,
                [EnumMember(Value = "promotional_credits")]
                PromotionalCredits,
                [EnumMember(Value = "prorated_credits")]
                ProratedCredits,
            }

            public int Amount() {
                return GetValue<int>("amount", true);
            }

            public string Description() {
                return GetValue<string>("description", false);
            }

            public EntityTypeEnum EntityType() {
                return GetEnum<EntityTypeEnum>("entity_type", true);
            }

            public string EntityId() {
                return GetValue<string>("entity_id", false);
            }

        }
        public class CreditNoteEstimateTax : Resource
        {

            public string Name() {
                return GetValue<string>("name", true);
            }

            public int Amount() {
                return GetValue<int>("amount", true);
            }

            public string Description() {
                return GetValue<string>("description", false);
            }

        }
        public class CreditNoteEstimateLineItemTax : Resource
        {

            public string LineItemId() {
                return GetValue<string>("line_item_id", false);
            }

            public string TaxName() {
                return GetValue<string>("tax_name", true);
            }

            public double TaxRate() {
                return GetValue<double>("tax_rate", true);
            }

            public bool? IsPartialTaxApplied() {
                return GetValue<bool?>("is_partial_tax_applied", false);
            }

            public bool? IsNonComplianceTax() {
                return GetValue<bool?>("is_non_compliance_tax", false);
            }

            public int TaxableAmount() {
                return GetValue<int>("taxable_amount", true);
            }

            public int TaxAmount() {
                return GetValue<int>("tax_amount", true);
            }

            public TaxJurisTypeEnum? TaxJurisType() {
                return GetEnum<TaxJurisTypeEnum>("tax_juris_type", false);
            }

            public string TaxJurisName() {
                return GetValue<string>("tax_juris_name", false);
            }

            public string TaxJurisCode() {
                return GetValue<string>("tax_juris_code", false);
            }

            public int? TaxAmountInLocalCurrency() {
                return GetValue<int?>("tax_amount_in_local_currency", false);
            }

            public string LocalCurrencyCode() {
                return GetValue<string>("local_currency_code", false);
            }

        }
        public class CreditNoteEstimateLineItemDiscount : Resource
        {
            public enum DiscountTypeEnum
            {
                UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
                [EnumMember(Value = "item_level_coupon")]
                ItemLevelCoupon,
                [EnumMember(Value = "document_level_coupon")]
                DocumentLevelCoupon,
                [EnumMember(Value = "promotional_credits")]
                PromotionalCredits,
                [EnumMember(Value = "prorated_credits")]
                ProratedCredits,
            }

            public string LineItemId() {
                return GetValue<string>("line_item_id", true);
            }

            public DiscountTypeEnum DiscountType() {
                return GetEnum<DiscountTypeEnum>("discount_type", true);
            }

            public string CouponId() {
                return GetValue<string>("coupon_id", false);
            }

            public int DiscountAmount() {
                return GetValue<int>("discount_amount", true);
            }

        }
        public class CreditNoteEstimateLineItemTier : Resource
        {

            public string LineItemId() {
                return GetValue<string>("line_item_id", false);
            }

            public int StartingUnit() {
                return GetValue<int>("starting_unit", true);
            }

            public int? EndingUnit() {
                return GetValue<int?>("ending_unit", false);
            }

            public int QuantityUsed() {
                return GetValue<int>("quantity_used", true);
            }

            public int UnitAmount() {
                return GetValue<int>("unit_amount", true);
            }

        }

        #endregion
    }
}
