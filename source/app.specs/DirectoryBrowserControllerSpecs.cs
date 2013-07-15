using Machine.Specifications;
using app.window;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
    [Subject(typeof(DirectoryBrowserController))]
    public class DirectoryBrowserControllerSpecs
    {
        public abstract class concern : Observes<IBrowserDirectory,
                                            DirectoryBrowserController>
        {
            
        }

        public class when_displaying_directory_in_tree : concern
        {
            Establish c = () =>
            {
                find_directory = depends.on<IDirectoryFind>();
            };

            Because b = () =>
               sut.browse_directory("dummy path");

            It should_find_the_directory_information = () =>
               find_directory.received(x => x.get_directory_info("dummy path"));

            private static IDirectoryFind find_directory;
        }
    }

    
}
