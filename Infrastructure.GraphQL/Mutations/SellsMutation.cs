using AutoMapper;
using Domain.Core.Sells;
using Domain.Core.Sells.PaymentRules;
using Domain.Core.Sells.Service;
using HotChocolate.Subscriptions;

using Infrastructure.DTO.Sells;
using Infrastructure.DTO.Sells.PaymentRules;

using Infrastructure.GraphQL.Subscriptions;
using Infrastructure.GraphQL.Exceptions;
using Infrastructure.GraphQL.Attributes;

#region TYPEDEF
using Dates = DAL.Repository<Domain.Core.Sells.PaymentRules.PaymentDate>;
using Rules = DAL.Repository<Domain.Core.Sells.PaymentRules.PaymentRule>;
using Payments = DAL.Repository<Domain.Core.Sells.Payment>;
#endregion


namespace Infrastructure.GraphQL.Mutations
{
    [GQLMutation]
    [ExtendObjectType("Mutations")]
    public class SellsMutation
    {
        private readonly IMapper mapper;

        public SellsMutation(IMapper mapper)
            => this.mapper = mapper;
        

        #region PaymentDate
        [UseProjection]
        [UseFiltering]
        public async Task<PaymentDate> CreatePaymentDate(PaymentDateDTO payload,
                                                        [Service] ITopicEventSender sender,
                                                        [Service] Dates dates)
        {
            var paymentDate = mapper.Map<PaymentDate>(payload);
            await dates.CreateAsync(paymentDate);
            await sender.SendAsync(nameof(SellsSubscription.OnPaymentDateCreated), paymentDate);
            return paymentDate;
        }

        [UseProjection]
        [UseFiltering]
        public async Task<PaymentDate> UpdatePaymentDate(PaymentDateDTO payload,
                                                        [Service] ITopicEventSender sender,
                                                        [Service] Dates dates)
        {
            var paymentDate = mapper.Map<PaymentDate>(payload);
            try
            {
                await dates.UpdateAsync(paymentDate);
                await sender.SendAsync(nameof(SellsSubscription.OnPaymentDateChanged), paymentDate);
                return paymentDate;
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new NotFound($"PaymentDate with id == {paymentDate.Id} not found", paymentDate.Id);
            }
            catch
            {
                throw;
            }
        }


        [UseFiltering]
        public async Task<PaymentDate> RemovePaymentDate(PaymentDateDTO payload,
                                                        [Service] ITopicEventSender sender,
                                                        [Service] Dates dates)
        {
            var paymentDate = mapper.Map<PaymentDate>(payload);
            try
            {
                await dates.DeleteAsync(paymentDate.Id);
                await sender.SendAsync(nameof(SellsSubscription.OnPaymentDateRemoved), paymentDate);
                return paymentDate;
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new NotFound($"PaymentDate with id == {paymentDate.Id} not found", paymentDate.Id);
            }
            catch
            {
                throw;
            }
        }
        #endregion



        #region PaymentRule
        [UseProjection]
        [UseFiltering]
        public async Task<PaymentRule> CreatePaymentRule(PaymentRuleDTO payload,
                                                        [Service] ITopicEventSender sender,
                                                        [Service] Rules rules)
        {
            var paymentRule = mapper.Map<PaymentRule>(payload);
            await rules.CreateAsync(paymentRule);
            await sender.SendAsync(nameof(SellsSubscription.OnPaymentRuleCreated), paymentRule);
            return paymentRule;
        }

        [UseProjection]
        [UseFiltering]
        public async Task<PaymentRule> UpdatePaymentRule(PaymentRuleDTO payload,
                                                        [Service] ITopicEventSender sender,
                                                        [Service] Rules rules)
        {
            var paymentRule = mapper.Map<PaymentRule>(payload);
            try
            {
                await rules.UpdateAsync(paymentRule);
                await sender.SendAsync(nameof(SellsSubscription.OnPaymentRuleChanged), paymentRule);
                return paymentRule;
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new NotFound($"PaymentRule with id == {paymentRule.Id} not found", paymentRule.Id);
            }
            catch
            {
                throw;
            }
        }


        [UseFiltering]
        public async Task<PaymentRule> RemovePaymentRule(PaymentRuleDTO payload,
                                                        [Service] ITopicEventSender sender,
                                                        [Service] Rules rules)
        {
            var paymentRule = mapper.Map<PaymentRule>(payload);
            try
            {
                await rules.DeleteAsync(paymentRule.Id);
                await sender.SendAsync(nameof(SellsSubscription.OnPaymentRuleRemoved), paymentRule);
                return paymentRule;
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new NotFound($"PaymentRule with id == {paymentRule.Id} not found", paymentRule.Id);
            }
            catch
            {
                throw;
            }
        }
        #endregion



        #region Payment
        [UseProjection]
        [UseFiltering]
        public async Task<Payment> CreatePayment(PaymentDTO payload,
                                                [Service] ITopicEventSender sender,
                                                [Service] Payments payments)
        {
            var payment = mapper.Map<Payment>(payload);
            await payments.CreateAsync(payment);
            await sender.SendAsync(nameof(SellsSubscription.OnPaymentCreated), payment);
            return payment;
        }

        [UseProjection]
        [UseFiltering]
        public async Task<Payment> UpdatePayment(PaymentDTO payload,
                                                [Service] ITopicEventSender sender,
                                                [Service] Payments payments)
        {
            var payment = mapper.Map<Payment>(payload);
            try
            {
                await payments.UpdateAsync(payment);
                await sender.SendAsync(nameof(SellsSubscription.OnPaymentCreated), payment);
                return payment;
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new NotFound($"Payment with id == {payment.Id} not found", payment.Id);
            }
            catch
            {
                throw;
            }
        }


        [UseFiltering]
        public async Task<Payment> RemovePayment(PaymentDTO payload,
                                                [Service] ITopicEventSender sender,
                                                [Service] Payments payments)
        {
            var payment = mapper.Map<Payment>(payload);
            try
            {
                await payments.DeleteAsync(payment.Id);
                await sender.SendAsync(nameof(SellsSubscription.OnPaymentRemoved), payment);
                return payment;
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new NotFound($"Payment with id ==  {payment.Id} not found", payment.Id);
            }
            catch
            {
                throw;
            }
        }
        #endregion
    }
}
