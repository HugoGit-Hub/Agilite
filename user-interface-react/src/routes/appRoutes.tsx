import HomePage from "../pages/home/HomePage";
import { RouteType } from "./config";
import DashboardPageLayout from "../pages/dashboard/DashboardPageLayout";
import PlanningPage from "../pages/dashboard/planning/PlanningPage";
import DashboardIndex from "../pages/dashboard/DashboardIndex";
import DashboardIcon from '@mui/icons-material/Dashboard';
import HomeIcon from '@mui/icons-material/Home';
import ContactPage from "../pages/contact/ContactPage";
import QuestionAnswerIcon from '@mui/icons-material/QuestionAnswer';
import CalendarTodayIcon from '@mui/icons-material/CalendarToday';

const appRoutes: RouteType[] = [
    {
        index: true,
        path: "/",
        element: <HomePage />,
        state: "accueil",
        sidebarProps: {
            displayText: "Accueil",
            icon: <HomeIcon />
        }
    },
    {
        path: "/dashboard",
        element: <DashboardPageLayout />,
        state: "dashboard",
        sidebarProps: {
            displayText: "Dashboard",
            icon: <DashboardIcon />
        },
        child: [
            {
                index: true,
                element: <DashboardIndex />,
                state: "dashboard.index",
            },
            {
                path: "/dashboard/planning",
                element: <PlanningPage />,
                state: "dashboard.planning",
                sidebarProps: {
                    displayText: "Planning",
                    icon: <CalendarTodayIcon sx={{ marginLeft: "25px" }} />
                },
            },
        ]
    },
    {
        path: "/contact",
        element: <ContactPage />,
        state: "contact",
        sidebarProps: {
            displayText: "Contact",
            icon: <QuestionAnswerIcon />
        }
    }
];

export default appRoutes;