

vrpn = {
  type = "vrpn";
  input_name = "vrpn";
  buttons = {
    --"WiiMote0@projector.cse.unr.edu";
  };
  analogs = {
    --"WiiMote0@projector.cse.unr.edu";
  };
  sixdofs = {
    "WiiMote0@tracker.rd.unr.edu";
    --"ShortGlasses@tracker.rd.unr.edu";
  };
};

master = {
  hostname = HOSTNAME;--"hpcvis10";
  ssh = HOSTNAME;--"hpcvis10";--"chase@" .. HOSTNAME;
  address = HOSTNAME;--"tcp://hpcvis1:8000";
  plugins = {
    vrpn = vrpn;
  };
};


other = {
  hostname = "hpcvis7";
  ssh = "hpcvis7";
  address = "hpcvis7";--"tcp://" .. "hpcvis7" .. ":8888";
  plugins = {
    x11_renderer = x11_renderer;
    vrpn = vrpn;
  };
};


machines = {
  master=master;
  --other = other;
  --self3 = others2;
};
