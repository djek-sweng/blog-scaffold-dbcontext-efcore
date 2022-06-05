using System;
using System.Linq;
using Scaffold.Library.Data;
using Scaffold.Library.Models;

namespace Scaffold.App;

public static class Demo
{
    public static void StartMinimal()
    {
        /*
         * Add database context into scope.
         */
        using var context = new DatabaseContext();

        /*
         * Add calendar.
         */
        var calendar = Calendar.Create(
            owner: "Arthur Dent"
        );
        context.Calendars.Add(calendar);
        context.SaveChanges();

        /*
         * Add meeting to calendar.
         */
        var meeting = Meeting.Create(
            title: "Have lunch with Zaphod Beeblebrox",
            description: "Ford's semi-half-cousin likes tea",
            duration: 42,
            startAt: DateTime.UtcNow.AddDays(10),
            calendarId: calendar.Id
        );
        context.Meetings.Add(meeting);
        context.SaveChanges();

        /*
         * Check meeting start date.
         */
        Console.WriteLine($"Does meeting '{meeting.Title}' start in future? " +
                          $"{meeting.IsStartInFuture()}.");

        /*
         * Add reminders to meeting.
         */
        context.Reminders.AddRange(
            Reminder.Create(
                remindBefore: 4,
                meetingId: meeting.Id),
            Reminder.Create(
                remindBefore: 2,
                meetingId: meeting.Id)
        );
        context.SaveChanges();
    }

    public static void Start()
    {
        const string arthur = "Arthur Dent";
        const string ford = "Ford Perfect";

        Console.WriteLine("Add database context to scope.");
        using var context = new DatabaseContext();

        Console.WriteLine("Add calendar.");
        var calendar = Calendar.Create(
            owner: arthur
        );
        context.Calendars.Add(calendar);
        context.SaveChanges();

        Console.WriteLine($"Is '{arthur}' the calendar owner? " +
                          $"{calendar.IsOwner(arthur)}.");
        Console.WriteLine($"Is '{ford}' the calendar owner? " +
                          $"{calendar.IsOwner(ford)}.");

        Console.WriteLine("Add meeting to calendar.");
        var meeting0 = Meeting.Create(
            title: "Have lunch with Zaphod Beeblebrox",
            description: "Ford's semi-half-cousin likes tea",
            duration: 42,
            startAt: DateTime.UtcNow.AddDays(299),
            calendarId: calendar.Id
        );
        context.Meetings.Add(meeting0);
        context.SaveChanges();

        Console.WriteLine($"Does meeting '{meeting0.Title}' start in future? " +
                          $"{meeting0.IsStartInFuture()}.");

        Console.WriteLine("Update meeting.");
        var meeting1 = context.Meetings.First(m => m.Id == meeting0.Id);

        meeting1.StartAt = DateTime.UtcNow.AddDays(-667);
        context.SaveChanges();

        Console.WriteLine($"Does meeting '{meeting1.Title}' start in future? " +
                          $"{meeting1.IsStartInFuture()}.");

        Console.WriteLine("Add reminders to meeting.");
        context.Reminders.AddRange(
            Reminder.Create(
                remindBefore: 271,
                meetingId: meeting1.Id),
            Reminder.Create(
                remindBefore: 662,
                meetingId: meeting1.Id)
        );
        context.SaveChanges();
    }
}
