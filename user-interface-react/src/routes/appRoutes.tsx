import HomePage from "../pages/home/HomePage";
import { RouteType } from "./config";
import DashboardPageLayout from "../pages/dashboard/DashboardPageLayout";
import DefaultPage from "../pages/dashboard/DefaultPage";
import DashboardIndex from "../pages/dashboard/DashboardIndex";
import TestPage from "../pages/dashboard/TestPage";
import FormatListBulletedIcon from '@mui/icons-material/FormatListBulleted';
import DashboardIcon from '@mui/icons-material/Dashboard';

const appRoutes: RouteType[] = [
    {
        index: true,
        element: <HomePage />,
        state: "home"
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
                path: "/dashboard/default",
                element: <DefaultPage />,
                state: "dashboard.default",
                sidebarProps: {
                    displayText: "Default",
                },
            },
        ]
    },
    {
        path: "/test",
        element: <TestPage />,
        state: "test",
        sidebarProps: {
            displayText: "test",
            icon: <FormatListBulletedIcon />
        }
    }
];

export default appRoutes;