using API.Gate.GraphQl.Exceptions;
using DAL;
using Domain.Core.Sells;
using Domain.Core.Sells.PaymentRules;
using Domain.Core.Sells.Service;

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
        public async Task<PaymentDate> CreatePaymentDate(PaymentDate paymentDate)
        {
            await this.paymentDateRepository.CreateAsync(paymentDate);
            return paymentDate;
        }

        [UseProjection]
        [UseFiltering]
        public async Task<PaymentDate> UpdatePaymentDate(PaymentDate paymentDate)
        {
            try
            {
                await this.paymentDateRepository.UpdateAsync(paymentDate);
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
        public async Task<PaymentDate> RemovePaymentDate(PaymentDate paymentDate)
        {
            try
            {
                await this.paymentDateRepository.DeleteAsync(paymentDate.Id);
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
        public async Task<PaymentRule> CreatePaymentDate(PaymentRule paymentRule)
        {
            await this.paymentRuleRepository.CreateAsync(paymentRule);
            return paymentRule;
        }

        [UseProjection]
        [UseFiltering]
        public async Task<PaymentRule> UpdatePaymentDate(PaymentRule paymentRule)
        {
            try
            {
                await this.paymentRuleRepository.UpdateAsync(paymentRule);
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
        public async Task<PaymentRule> RemovePaymentDate(PaymentRule paymentRule)
        {
            try
            {
                await this.paymentRuleRepository.DeleteAsync(paymentRule.Id);
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
        public async Task<Payment> CreatePayment(Payment payment)
        {
            await this.paymentRepository.CreateAsync(payment);
            return payment;
        }

        [UseProjection]
        [UseFiltering]
        public async Task<Payment> UpdatePayment(Payment payment)
        {
            try
            {
                await this.paymentRepository.UpdateAsync(payment);
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
        public async Task<Payment> RemovePayment(Payment payment)
        {
            try
            {
                await this.paymentRepository.DeleteAsync(payment.Id);
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
