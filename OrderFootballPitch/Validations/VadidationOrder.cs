//using OrderFootballPitch.DTOs;

//namespace OrderFootballPitch.Validations
//{
//    public class OrderValidator : AbstractValidator<OrderDTO>
//    {
//        public OrderValidator(ApplicationDbContext context)
//        {
//            RuleFor(x => x.Email).EmailAddress().WithMessage("Email is not valid.");
//            RuleFor(x => x.Phone).Matches(@"^\d{10}$").WithMessage("Phone number is not valid.");

//            RuleFor(x => x)
//                .Must(x => !context.Orders.Any(o =>
//                    o.StartAt < x.EndAt && o.EndAt > x.StartAt &&
//                    o.FootballPitchId == x.FootballPitchId))
//                .WithMessage("The time slot is already booked.");

//            RuleFor(x => x.DiscountId)
//                .Must(id => context.Discounts.Any(d => d.Id == id))
//                .When(x => x.DiscountId.HasValue)
//                .WithMessage("Discount code is not valid.");
//        }
//    }
//}
