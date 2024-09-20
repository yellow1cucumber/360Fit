using Domain.Core.Sells;
using Domain.Core.Sells.PaymentRules;

namespace Infrastructure.GraphQL.Subscriptions
{
    [ExtendObjectType("Subscriptions")]
    public class SellsSubscription
    {
        #region PaymentDate
        [Subscribe]
        public PaymentDate OnPaymentDateCreated([EventMessage] PaymentDate paymentDate)
            => paymentDate;

        [Subscribe]
        public PaymentDate OnPaymentDateChanged([EventMessage] PaymentDate paymentDate)
            => paymentDate;

        [Subscribe]
        public PaymentDate OnPaymentDateRemoved([EventMessage] PaymentDate paymentDate)
            => paymentDate;
        #endregion


        #region PaymentRule
        [Subscribe]
        public PaymentRule OnPaymentRuleCreated([EventMessage] PaymentRule paymentRule)
            => paymentRule;

        [Subscribe]
        public PaymentRule OnPaymentRuleChanged([EventMessage] PaymentRule paymentRule)
            => paymentRule;

        [Subscribe]
        public PaymentRule OnPaymentRuleRemoved([EventMessage] PaymentRule paymentRule)
            => paymentRule;
        #endregion


        #region Payment
        [Subscribe]
        public Payment OnPaymentCreated([EventMessage] Payment payment)
            => payment;

        [Subscribe]
        public Payment OnPaymentChanged([EventMessage] Payment payment)
            => payment;

        [Subscribe]
        public Payment OnPaymentRemoved([EventMessage] Payment payment)
            => payment;
        #endregion
    }
}
