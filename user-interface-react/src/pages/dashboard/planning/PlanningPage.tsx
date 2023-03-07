import FullCalendar from '@fullcalendar/react';
import dayGridPlugin from "@fullcalendar/daygrid";
import frLocale from '@fullcalendar/core/locales/fr';
import listPlugin from '@fullcalendar/list';

export default function PlanningPage() 
{
  return (
    <FullCalendar
      plugins={[ dayGridPlugin, listPlugin ]}
      initialView="dayGridMonth"
      firstDay={1}
      locale={frLocale}
      fixedWeekCount={false}
      height={'80vh'}
      headerToolbar={{
        left: "prev,next today",
        center: "title",
        right: "dayGridMonth,dayGridWeek,dayGridDay,listWeek",
      }}
      events={[
        {
        title: "test",
        start: "2023-02-17T16:00:00",
        },
        {
          title: "meeting",
          start: "2023-02-19T10:30:00",
        },
        {
          title: "dev",
          start: "2023-02-19T14:00:00",
        },
        {
          title: 'Meeting',
          start: '2023-02-16T10:30:00',
          end: '2023-02-16T12:30:00'
        }
      ]}
    />
  );
}