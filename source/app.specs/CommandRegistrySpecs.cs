using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using app.web.core;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace app.specs
{
  [Subject(typeof(CommandRegistry))]
  public class CommandRegistrySpecs
  {
    public abstract class concern : Observes<IFindCommands,
                                      CommandRegistry>
    {
    }

    public class when_finding_a_command_that_can_process_a_request : concern
    {
      public class and_it_has_the_command
      {
        Establish c = () =>
        {
          all_the_commands = new List<IProcessOneRequest>();
          depends.on<IEnumerable<IProcessOneRequest>>(all_the_commands);

          request = fake.an<IContainRequestInformation>();
          the_command_that_can_process_the_request = fake.an<IProcessOneRequest>();
          Enumerable.Range(1,1000).each(x => all_the_commands.Add(fake.an<IProcessOneRequest>()));
          all_the_commands.Add(the_command_that_can_process_the_request);

          the_command_that_can_process_the_request.setup(x => x.can_process(request)).Return(true);
        };

        Because b = () =>
          result = sut.get_command_that_can_process(request);

        It should_return_the_command_to_the_caller = () =>
          result.ShouldEqual(the_command_that_can_process_the_request);

        static IProcessOneRequest result;
        static IProcessOneRequest the_command_that_can_process_the_request;
        static IContainRequestInformation request;
        static IList<IProcessOneRequest> all_the_commands;
      }

      public class and_it_does_not_have_the_command
      {
        Establish c = () =>
        {
          the_missing_request_command = fake.an<IProcessOneRequest>();
          all_the_commands = new List<IProcessOneRequest>();
          depends.on<IEnumerable<IProcessOneRequest>>(all_the_commands);

          depends.on<ICreateTheMissingCommand>(x =>
          {
            x.ShouldEqual(request);
            return the_missing_request_command;
          });

          request = fake.an<IContainRequestInformation>();
        };

        Because b = () =>
          result = sut.get_command_that_can_process(request);

        It should_return_the_missing_request_command_to_the_caller = () =>
          result.ShouldEqual(the_missing_request_command);

        static IProcessOneRequest result;
        static IProcessOneRequest the_missing_request_command;
        static IContainRequestInformation request;
        static IList<IProcessOneRequest> all_the_commands;
      }
    }
  }
}