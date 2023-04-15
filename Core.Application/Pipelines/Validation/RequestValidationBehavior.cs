using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Pipelines.Validation
{
    public class RequestValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
     where TRequest : IRequest<TResponse>
    {
        //Burada mediatR kütüphanesi kullanarak request işlenmeden araya girip validasyon işlemleri yapılır.
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public RequestValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        /*
            Burada gelen istek için ValidationContext kullarak bir context nesnesi olusturuyoruz.
            Sonra her bir doğrulama işlemini ValidationTool'daki  validate metodunu kullarak 
            context nesnesine uyguluyoruz.
            context'in geçemediği validasyonları selectMany ile alıyoruz.
             Eğer failures listesi null değilse hataları listeye çeviyoruz
            failures count'u 0 farklı ise validasyon hatası olarak hataları fırlatıyoruz Eğer 0 ise next ile devam
        */

        public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, 
                                            CancellationToken cancellationToken)
        {
            ValidationContext<object> context = new(request);
            List<ValidationFailure> failures = _validators
                                               .Select(validator => validator.Validate(context))
                                               .SelectMany(result => result.Errors)
                                               .Where(failure => failure != null)
                                               .ToList();
            if (failures.Count != 0) throw new ValidationException(failures);
            return next();
        }
    }
}
