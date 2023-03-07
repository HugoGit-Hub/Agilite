import sizeConfigs from "../../configs/sizeConfigs"
import colorConfigs from "../../configs/colorConfigs"
import { AppBar, Toolbar, Typography } from "@mui/material"
import { styled, alpha } from '@mui/material/styles';
import SearchIcon from '@mui/icons-material/Search';
import InputBase from '@mui/material/InputBase';
import useMediaQuery from '@mui/material/useMediaQuery';

const Search = styled('div')(({ theme }) => ({
  position: 'relative',
  border: 'solid 1px black',
  borderRadius: theme.shape.borderRadius,
  backgroundColor: alpha(theme.palette.common.white, 0.15),
  '&:hover': {
    backgroundColor: alpha(theme.palette.common.white, 0.25),
  },
  marginLeft: 0,
  width: '100%',
  [theme.breakpoints.up('sm')]: {
    marginLeft: theme.spacing(1),
    width: 'auto',
  },
}));

const SearchIconWrapper = styled('div')(({ theme }) => ({
  padding: theme.spacing(0, 2),
  height: '100%',
  position: 'absolute',
  pointerEvents: 'none',
  display: 'flex',
  alignItems: 'center',
  justifyContent: 'center',
}));

const StyledInputBase = styled(InputBase)(({ theme }) => ({
  color: 'inherit',
  '& .MuiInputBase-input': {
    padding: theme.spacing(1, 1, 1, 0),
    paddingLeft: `calc(1em + ${theme.spacing(4)})`,
    transition: theme.transitions.create('width'),
    width: '100%',
    [theme.breakpoints.up('sm')]: {
      width: '12ch',
      '&:focus': {
        width: '20ch',
      },
    },
  },
}));

const TopBar = () => {
  const mediaquery = useMediaQuery('(min-width:900px)');

  return (
    <AppBar
      position="fixed"
      sx={{
        width: "100%",
        ml: sizeConfigs.sideBar.width,
        boxShadow: "unset",
        backgroundColor: colorConfigs.topbar.bg,
        color: colorConfigs.topbar.color,
        left: "0"
      }}
    >
      <Toolbar>
        <Typography variant="h6">
          Bonjour [User.Name] !
        </Typography>
        <Typography
          sx={{
            position: "fixed",
            right: "0",
            marginRight: "15px"
          }}
        >
          {mediaquery && <Search>
            <SearchIconWrapper>
              <SearchIcon />
            </SearchIconWrapper>
            <StyledInputBase
              placeholder="Search…"
              inputProps={{ 'aria-label': 'search' }}
            />
          </Search>}
        </Typography>
      </Toolbar>
    </AppBar>
  );
}

export default TopBar