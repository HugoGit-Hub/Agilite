import { AppBar, Toolbar, Typography } from "@mui/material"
import sizeConfigs from "../../configs/sizeConfigs"
import colorConfigs from "../../configs/colorConfigs"

const TopBar = () => {
  return (
    <AppBar
      position="fixed"
      sx={{
        width: "85vw",
        ml: sizeConfigs.sideBar.width,
        boxShadow: "unset",
        backgroundColor: colorConfigs.topbar.bg,
        color: colorConfigs.topbar.color
      }}
    >
      <Toolbar>
        <Typography variant="h6">
            React Sidebar with dropdown
        </Typography>
      </Toolbar>
    </AppBar>
  )
}

export default TopBar