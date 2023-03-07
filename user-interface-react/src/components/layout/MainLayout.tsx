import { Box, Toolbar } from "@mui/material";
import { Outlet } from "react-router-dom";
import TopBar from "../shared/TopBar";
import sizeConfigs from "../../configs/sizeConfigs";
import SideBar from "../shared/SideBar";
import colorConfigs from "../../configs/colorConfigs";

const MainLayout = () => {
  return (
    <Box sx={{ display: "flex" }}>
      <TopBar />
      <Box
        component="nav"
        sx={{
          width: sizeConfigs.sideBar.width,
          flexShrink: 0,
          display: "contents"
        }}
      >
        <SideBar />
        <Box
          component="main"
          sx={{
            flexGrow: 1,
            p: 3,
            width: "100%",
            minHeight: "100vh",
            backgroundColor: colorConfigs.mainBg
          }}
        >
          <Toolbar sx={{ className: "phone" }}/>
          <Outlet />
        </Box>
      </Box>
    </Box>
  );
}

export default MainLayout