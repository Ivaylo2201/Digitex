using Backend.Domain.Entities;
using FluentValidation;

namespace Backend.Application.Validators;

public class GraphicsCardValidator : ProductValidatorBase<GraphicsCard>
{
    public GraphicsCardValidator()
    {
        // RuleFor(x => x.Memory.CapacityInGb).GreaterThanOrEqualTo(0);
        // RuleFor(x => x.ClockSpeed.Base).GreaterThanOrEqualTo(0);
        // RuleFor(x => x.ClockSpeed.Boost).GreaterThanOrEqualTo(0);
    }
}