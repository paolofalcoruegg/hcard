
user_data = csvread('user_data.txt');
path_data = csvread('Path data - Sheet1.csv');

timeuser = user_data(1:end,1);
alpha = user_data(1:end,2);
beta = user_data(1:end,3);
yuser = user_data(1:end,4);
xuser = user_data(1:end,5);

ypath = path_data(1:end,3);
xpath = path_data(1:end,2);
timepath = path_data(1:end,1);

fitpath = fit(xpath,ypath,'linearinterp');

x = 0:0.1:650;
figure
plot(x,fitpath(x));


figure
subplot(3,1,1);
plot(xuser,yuser,xpath,ypath)
subplot(3,1,2);
plot(timeuser,alpha)
subplot(3,1,3);
plot(timeuser,beta)

max_angle_right = max(alpha);
max_angle_left = min(alpha);
max_angle_forward = max(beta);
max_angle_backward = min(beta);

