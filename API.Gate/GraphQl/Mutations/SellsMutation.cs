using API.Gate.GraphQl.Exceptions;
using API.Gate.GraphQl.Subscriptions;
using DAL;
using Domain.Core.Sells;
using Domain.Core.Sells.PaymentRules;
using Domain.Core.Sells.Service;
using HotChocolate.Subscriptions;

namespace API.Gate.GraphQl.Mutations
{
    [ExtendObjectType("Mutations")]
    public class SellsMutation
    {
        private readonly Context context;
        private readonly Repository<PaymentDate> paymentDateRepository;
        private readonly Repository<PaymentRule> paymentRuleRepository;
        private readonly Repository<Payment> paymentRepository;

        public SellsMutation([Service] Context context)
        {
            this.context = context;
            this.paymentDateRepository = new Repository<PaymentDate>(context);
            this.paymentRuleRepository = new Repository<PaymentRule>(context);
            this.paymentRepository = new Repository<Payment>(context);
        }

        #region PaymentDate
        [UseProjection]
        [UseFiltering]
        public async Task<PaymentDate> CreatePaymentDate(PaymentDate paymentDate,
                                                        [Service] ITopicEventSender sender)
        {
            await this.paymentDateRepository.CreateAsync(paymentDate);
            await sender.SendAsync(nameof(SellsSubscription.OnPaymentDateCreated), paymentDate);
            return paymentDate;
        }

        [UseProjection]
        [UseFiltering]
        public async Task<PaymentDate> UpdatePaymentDate(PaymentDate paymentDate,
                                                        [Service] ITopicEventSender sender)
        {
            try
            {
                await this.paymentDateRepository.UpdateAsync(paymentDate);
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
        public async Task<PaymentDate> RemovePaymentDate(PaymentDate paymentDate, 
                                                        [Service] ITopicEventSender sender)
        {
            try
            {
                await this.paymentDateRepository.DeleteAsync(paymentDate.Id);
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
        public async Task<PaymentRule> CreatePaymentRule(PaymentRule paymentRule, 
                                                        [Service] ITopicEventSender sender)
        {
            await this.paymentRuleRepository.CreateAsync(paymentRule);
            await sender.SendAsync(nameof(SellsSubscription.OnPaymentRuleCreated), paymentRule);
            return paymentRule;
        }

        [UseProjection]
        [UseFiltering]
        public async Task<PaymentRule> UpdatePaymentRule(PaymentRule paymentRule, 
                                                        [Service] ITopicEventSender sender)
        {
            try
            {
                await this.paymentRuleRepository.UpdateAsync(paymentRule);
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
        public async Task<PaymentRule> RemovePaymentRule(PaymentRule paymentRule, 
                                                        [Service] ITopicEventSender sender)
        {
            try
            {
                await this.paymentRuleRepository.DeleteAsync(paymentRule.Id);
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
        public async Task<Payment> CreatePayment(Payment payment,
                                                [Service] ITopicEventSender sender)
        {
            await this.paymentRepository.CreateAsync(payment);
            await sender.SendAsync(nameof(SellsSubscription.OnPaymentCreated), payment);
            return payment;
        }

        [UseProjection]
        [UseFiltering]
        public async Task<Payment> UpdatePayment(Payment payment, 
                                                [Service] ITopicEventSender sender)
        {
            try
            {
                await this.paymentRepository.UpdateAsync(payment);
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
        public async Task<Payment> RemovePayment(Payment payment,
                                                [Service] ITopicEventSender sender)
        {
            try
            {
                await this.paymentRepository.DeleteAsync(payment.Id);
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
