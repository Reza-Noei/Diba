using System.Collections.Generic;
using System.Linq;
using Diba.Tests.Acceptance.Feature.Product.Model;

namespace Diba.Tests.Acceptance.Feature.Product.Mappers
{
    public static class SelectiveConstraintsMappers
    {
        public static SelectiveConstraintsCommand Map(SelectiveConstraints selectiveConstraints)
        {
            List<OptionCommand> optionCommand = new List<OptionCommand>();  
            var optionsDictionary = selectiveConstraints.Options.Split(',').Select(x => x.Split('='))
               .ToDictionary(x => int.Parse(x[0]), x => x[1]);
            
            foreach (var keyValuePair in optionsDictionary)
            {
                var option = new OptionCommand()
                {
                    Key = keyValuePair.Key,
                    Value = keyValuePair.Value
                };

                optionCommand.Add(option);
            }

            return new SelectiveConstraintsCommand()
            {
                Title = selectiveConstraints.Title,
                Options = optionCommand
            };
        }

    }
}