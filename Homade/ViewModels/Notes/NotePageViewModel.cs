using System.Collections.ObjectModel;
using Homade.Controllers.Notes;
using Homade.Models.Notes;

namespace Homade.ViewModels.Notes;

public class NotePageViewModel
{
    private readonly NoteController _noteController = NoteController.Instance;
    
    public ObservableCollection<Note> Notes { get; set; }
    
    public NotePageViewModel()
    {
        Notes = [];
        LoadNotes();
    }

    private void LoadNotes()
    {
        Notes.Clear();
        foreach (var note in _noteController.GetAll())
            Notes.Add(note);
    }
}