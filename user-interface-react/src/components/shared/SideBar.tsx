import { Avatar, Drawer, List, Stack, Toolbar } from "@mui/material"
import sizeConfigs from "../../configs/sizeConfigs"
import assets from "../../assets"
import colorConfigs from "../../configs/colorConfigs"
import appRoutes from "../../routes/appRoutes"
import SidebarItemCollapse from "./SidebarItemCollapse"
import SideBarItem from "./SideBarItem"

const SideBar = () => {
  return (
    <Drawer
      variant="permanent"
      sx={{
        width: sizeConfigs.sideBar.width,
        flexShrink: 0,
        "& .MuiDrawer-paper": {
          width: sizeConfigs.sideBar.width,
          boxSizing: "border-box",
          borderRight: "0px",
          backgroundColor: colorConfigs.sidebar.bg,
          color: colorConfigs.sidebar.color
        }
      }}
    >
      <List disablePadding>
        <Toolbar sx={{ marginBottom: "20px" }}>
          <Stack
            sx={{ width: "100%"}}
            direction="row"
            justifyContent="center"
          >
            <Avatar src={assets.images.logo} 
              sx={{ 
                borderRadius: "0%",
                width: "unset"
              }}
            />
          </Stack>
        </Toolbar>
        {appRoutes.map((route, index) => (
          route.sidebarProps ? (
            route.child ? (
              <SidebarItemCollapse item={route} key={index} />
            ) : (
              <SideBarItem item={route} key={index} />
            )
          ) : null
        ))}
      </List>
    </Drawer>
  );
}

export default SideBar