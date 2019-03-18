
% read data files
user_data = csvread('user_data.txt');
path_data = csvread('Path data - Sheet1.csv');

%user variables
timeuser = user_data(1:end,1);
alpha = user_data(1:end,2);
beta = user_data(1:end,3);
yuser = user_data(1:end,4);
xuser = user_data(1:end,5);

%path variables
ypath = path_data(1:end,3);
xpath = path_data(1:end,2);
timepath = path_data(1:end,1);

%path function
fitpath = fit(xpath,ypath,'linearinterp');

x = 0:0.1:650;
figure
plot(x,fitpath(x));

% Figure showing user path compared to ideal path, angles
figure
subplot(3,1,1);
plot(xuser,yuser,xpath+15,ypath)
subplot(3,1,2);
plot(timeuser,alpha)
ylim([-20, 20])
subplot(3,1,3);
plot(timeuser,beta)
ylim([-20, 20])

% calculate max angles
max_angle_right = max(alpha);
max_angle_left = min(alpha);
max_angle_forward = max(beta);
max_angle_backward = min(beta);

deviation = abs(yuser - fitpath(xuser));
mean_dev = mean(deviation);



