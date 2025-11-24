using Homade.Models.Notes;
using Homade.Services.Notes;

namespace Homade.Controllers.Notes;

public class NoteController: AbstractController<NoteService, Note>
{
    private static NoteController? _instance;
    
    public static NoteController Instance => _instance ??= new NoteController();
    
    private NoteController()
    {
    }

    // TODO: persist (database, json, file, etc)
    protected override NoteService GetService()
    {
        return NoteService.Instance;
    }
}