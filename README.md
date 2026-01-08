# EventEase (Blazor) 

Scaffolded a minimal Blazor WebAssembly app with:
- `Event` model
- `EventService` with mock data
- `Shared/EventCard.razor` component (two-way binding to fields)
- Pages: `EventList`, `EventDetails`, `EventRegistration`

Added in Activity 3:
- `Registration` model with data annotations for validation (`Models/Registration.cs`)
- `UserSessionService` (persists last user in `localStorage` via JS interop)
- Attendance tracking in `EventService` with `RegisterAttendee` and `GetAttendees`
- `EventRegistration` page converted to `EditForm` with validation and session persistence
- `Attendance` page to list attendees for an event
- `EventCard` shows attendee count

Copilot assistance summary:
- Suggested component patterns and binding approaches for Blazor.
- Recommended `EditForm` and data annotations for form validation.
- Helped identify `Virtualize` as a performance option for large lists (not implemented by default).
- Guided use of `IJSRuntime` for lightweight session persistence.

Quick run:

```bash
cd EventEase
dotnet build
dotnet run
```

Open browser at `https://localhost:5001` (or as dotnet outputs).

To try registration and attendance:

```bash
cd EventEase
dotnet run
```

Navigate to `/`, click `Register` on an event, submit the form (name and valid email required). Then view attendees at `/attendance/{id}`.
