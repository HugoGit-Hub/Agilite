import { useState } from "react";
import { RouteType } from "../../routes/config"
import { Collapse, List, ListItemButton, ListItemIcon, ListItemText, Typography } from "@mui/material";
import colorConfigs from "../../configs/colorConfigs";
import ExpandLessIcon from '@mui/icons-material/ExpandLess';
import ExpandMoreIcon from '@mui/icons-material/ExpandMore';
import SideBarItem from "./SideBarItem";

type Props = {
    item: RouteType;
};

const SidebarItemCollapse = ({ item }: Props) => {
    const [open, setOpen] = useState(false);

  return (
    item.sidebarProps ? (
        <>
            <ListItemButton
                onClick={() => setOpen(!open)}
                sx={{
                    "&: hover": {
                        backgroundColor: colorConfigs.sidebar.hoverBg
                    },
                    paddingY: "12px",
                    paddingX: "24px"
                }}
            >
                <ListItemIcon
                    sx={{
                        color: colorConfigs.sidebar.color
                    }}
                >
                {item.sidebarProps.icon && item.sidebarProps.icon}
                </ListItemIcon>
                <ListItemText 
                    disableTypography
                    primary={
                        <Typography>
                            {item.sidebarProps.displayText}
                        </Typography>
                    }
                />
                {open ? <ExpandLessIcon /> : <ExpandMoreIcon />}
            </ListItemButton>
            <Collapse in={open} timeout="auto">
                <List>
                    {item.child?.map((route, index) => (
                        route.sidebarProps ? (
                            route.child ? (
                            <SidebarItemCollapse item={route} key={index} />
                            ) : (
                            <SideBarItem item={route} key={index} />
                            )
                        ) : null
                    ))}
                </List>
            </Collapse>
        </>
    ) : null
  );
};

export default SidebarItemCollapse;