using API.Gate.GraphQl.Exceptions;
using AutoMapper;
using DAL;
using Domain.Core.Sells;
using Domain.Core.Sells.PaymentRules;
using Domain.Core.Sells.Service;
using HotChocolate.Subscriptions;
using Infrastructure.DTO.Sells;
using Infrastructure.DTO.Sells.PaymentRules;
using Infrastructure.GraphQL.Subscriptions;

namespace Infrastructure.GraphQL.Mutations
{
    [ExtendObjectType("Mutations")]
    public class SellsMutation
    {
        private readonly Context context;
        private readonly Repository<PaymentDate> paymentDateRepository;
        private readonly Repository<PaymentRule> paymentRuleRepository;
        private readonly Repository<Payment> paymentRepository;

        private readonly IMapper mapper;

        public SellsMutation([Service] Context context, IMapper mapper)
        {
            this.context = context;
            paymentDateRepository = new Repository<PaymentDate>(context);
            paymentRuleRepository = new Repository<PaymentRule>(context);
            paymentRepository = new Repository<Payment>(context);
            this.mapper = mapper;
        }

        #region PaymentDate
        [UseProjection]
        [UseFiltering]
        public async Task<PaymentDate> CreatePaymentDate(PaymentDateDTO payload,
                                                        [Service] ITopicEventSender sender)
        {
            var paymentDate = mapper.Map<PaymentDate>(payload);
            await paymentDateRepository.CreateAsync(paymentDate);
            await sender.SendAsync(nameof(SellsSubscription.OnPaymentDateCreated), paymentDate);
            return paymentDate;
        }

        [UseProjection]
        [UseFiltering]
        public async Task<PaymentDate> UpdatePaymentDate(PaymentDateDTO payload,
                                                        [Service] ITopicEventSender sender)
        {
            var paymentDate = mapper.Map<PaymentDate>(payload);
            try
            {
                await paymentDateRepository.UpdateAsync(paymentDate);
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
                                                        [Service] ITopicEventSender sender)
        {
            var paymentDate = mapper.Map<PaymentDate>(payload);
            try
            {
                await paymentDateRepository.DeleteAsync(paymentDate.Id);
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
                                                        [Service] ITopicEventSender sender)
        {
            var paymentRule = mapper.Map<PaymentRule>(payload);
            await paymentRuleRepository.CreateAsync(paymentRule);
            await sender.SendAsync(nameof(SellsSubscription.OnPaymentRuleCreated), paymentRule);
            return paymentRule;
        }

        [UseProjection]
        [UseFiltering]
        public async Task<PaymentRule> UpdatePaymentRule(PaymentRuleDTO payload,
                                                        [Service] ITopicEventSender sender)
        {
            var paymentRule = mapper.Map<PaymentRule>(payload);
            try
            {
                await paymentRuleRepository.UpdateAsync(paymentRule);
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
                                                        [Service] ITopicEventSender sender)
        {
            var paymentRule = mapper.Map<PaymentRule>(payload);
            try
            {
                await paymentRuleRepository.DeleteAsync(paymentRule.Id);
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
                                                [Service] ITopicEventSender sender)
        {
            var payment = mapper.Map<Payment>(payload);
            await paymentRepository.CreateAsync(payment);
            await sender.SendAsync(nameof(SellsSubscription.OnPaymentCreated), payment);
            return payment;
        }

        [UseProjection]
        [UseFiltering]
        public async Task<Payment> UpdatePayment(PaymentDTO payload,
                                                [Service] ITopicEventSender sender)
        {
            var payment = mapper.Map<Payment>(payload);
            try
            {
                await paymentRepository.UpdateAsync(payment);
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
                                                [Service] ITopicEventSender sender)
        {
            var payment = mapper.Map<Payment>(payload);
            try
            {
                await paymentRepository.DeleteAsync(payment.Id);
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
