using Backend.Domain.Entities;
using FluentValidation;

namespace Backend.Application.Validators;

public class GraphicsCardsValidator : ProductValidatorBase<GraphicsCard>
{
    public GraphicsCardsValidator()
    {
        RuleFor(x => x.Memory.CapacityInGb).GreaterThanOrEqualTo(0);
        RuleFor(x => x.ClockSpeed.Base).GreaterThanOrEqualTo(0);
        RuleFor(x => x.ClockSpeed.Boost).GreaterThanOrEqualTo(0);
    }
}